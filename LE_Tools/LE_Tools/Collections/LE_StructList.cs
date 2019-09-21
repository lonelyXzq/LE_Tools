using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    public class LE_StructList<T> where T : struct
    {
        public const int Size = 64;

        private readonly Queue<int> emptyList;

        private readonly List<T> datas;

        private readonly List<ulong> mark;

        private int length;

        private int count;

        public T this[int index]
        {
            get => datas[index];
            set => datas[index] = value;
        }

        public int Length => length;
        public int Count => count;

        public LE_StructList()
        {
            datas = new List<T>();
            emptyList = new Queue<int>();
            mark = new List<ulong>();
        }

        public bool Check(int index)
        {
            if (index < 0 || index >= length)
            {
                return false;
            }
            int t = index / Size;
            int tmark = index % Size;
            ulong _c = 1ul << tmark;
            if ((mark[t] & _c) > 0)
            {
                return true;
            }
            return false;
        }

        public int Add(T data)
        {
            int index = length;
            if (emptyList.Count > 0)
            {
                index = emptyList.Dequeue();
                datas[index] = data;
            }
            else
            {
                datas.Add(data);
            }
            int t = index / 64;
            int tmark = index % 64;
            ulong _c = 1ul << tmark;
            if (t == mark.Count)
            {
                mark.Add(0);
            }
            mark[t] += _c;
            length++;
            count++;
            return index;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= length)
            {
                return;
            }
            int t = index / 64;
            int tmark = index % 64;
            ulong _c = 1ul << tmark;
            mark[t] &= (~_c);
            emptyList.Enqueue(index);
            count--;
        }

        public void Clear()
        {
            datas.Clear();
            emptyList.Clear();
            mark.Clear();
            length = 0;
            count = 0;
        }

    }
}
