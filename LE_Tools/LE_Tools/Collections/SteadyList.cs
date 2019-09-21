using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    class SteadyList<T> : ISList<T>
    {
        private readonly List<T> datas;

        private readonly Queue<int> empty;

        private int count;
        private int maxLength;

        public SteadyList()
        {
            datas = new List<T>();
            empty = new Queue<int>();
        }

        public T this[int index]
        {
            get
            {
                return datas[index];
            }
            set
            {
                datas[index] = value;
            }
        }

        public int Count => count;
        public int Length => maxLength;

        public int Add(T data)
        {
            int re = count;
            count++;
            if (empty.Count == 0)
            {
                datas.Add(data);
                maxLength++;
                return re;
            }
            else
            {
                re = empty.Dequeue();
                datas[re] = data;
                return re;
            }
        }


        public bool Check(int index)
        {
            if (index < 0 || index >= maxLength)
            {
                return false;
            }
            else if (datas[index] == default)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Clear()
        {
            datas.Clear();
            empty.Clear();
            count = 0;
            maxLength = 0;
        }

        public T[] FindData(Seek<T> seek)
        {
            List<T> re = new List<T>();
            for (int i = 0; i < maxLength; i++)
            {
                if (datas[i] != default && seek(datas[i]))
                {
                    re.Add(datas[i]);
                }
            }
            return re.ToArray();
        }

        public T[] GetAllDatas()
        {
            T[] re = new T[count];
            int j = 0;
            for (int i = 0; i < maxLength; i++)
            {
                if (datas[i] != default)
                {
                    re[j] = datas[i];
                    j++;
                }
            }
            return re;
        }

        public void Remove(int index)
        {
            if (!Check(index))
            {
                return;
            }
            count--;
            if (index == maxLength - 1)
            {
                datas.RemoveAt(index);
                maxLength--;
                return;
            }
            empty.Enqueue(index);
            datas[index] = default;
        }
    }
}
