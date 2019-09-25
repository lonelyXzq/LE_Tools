using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.ObjectPool
{
    public interface IObjectPool<T>
    {
        T GetObject();
        void RemoveObject(int id);

        void RemoveObject(T data);

        void Clear();
    }
}
