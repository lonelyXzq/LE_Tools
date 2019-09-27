using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LE_Tools.Collections
{
    /// <summary>
    /// id不复用
    /// 多线程安全
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafetySList<T>
    {
        private readonly ConcurrentDictionary<int, T> datas;

        private volatile int nextId;

        public T this[int index] { get => datas[index]; set => datas[index] = value; }

        public int Count => datas.Count;

        public SafetySList()
        {
            datas = new ConcurrentDictionary<int, T>();
            nextId = -1;
        }

        public int Add(T data)
        {
            int _id = Interlocked.Increment(ref nextId);
            while (!datas.TryAdd(_id, data))
            {

            }
            return _id;
        }

        public bool Check(int index)
        {
            return datas.ContainsKey(index);
        }

        public void Clear()
        {
            datas.Clear();
        }

        public T[] FindData(Seek<T> seek)
        {
            List<T> ts = new List<T>();
            foreach (var data in datas.Values)
            {
                if (seek.Invoke(data))
                {
                    ts.Add(data);
                }
            }
            return ts.ToArray();
        }

        public T[] GetAllDatas()
        {
            return datas.Values.ToArray();
        }

        public T GetData(int id)
        {
            if (datas.TryGetValue(id, out T data))
            {
                return data;
            }
            return default;
        }

        public void Remove(int index)
        {
            if (datas.ContainsKey(index))
            {
                while (!datas.TryRemove(index, out _))
                {

                }
            }
        }
    }
}
