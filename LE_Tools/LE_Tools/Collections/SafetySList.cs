using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    public class SafetySList<T> : ISList<T>
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public int Add(T data)
        {
            throw new NotImplementedException();
        }

        public bool Check(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T[] FindData(Seek<T> seek)
        {
            throw new NotImplementedException();
        }

        public T[] GetAllDatas()
        {
            throw new NotImplementedException();
        }

        public T GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
