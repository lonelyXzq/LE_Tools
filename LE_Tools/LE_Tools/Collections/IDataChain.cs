using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    public delegate bool Seek<T>(T data);
    interface IDataChain<T>
    {
        bool CheckData(int id);

        int Add(T data);

        T GetData(int id);

        T[] GetAllData();

        T[] FindData(Seek<T> seek);

        void RemoveData(int id);
    }
}
