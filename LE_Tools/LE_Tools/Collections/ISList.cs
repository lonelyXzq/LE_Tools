using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{

    interface ISList<T>
    {
        int Count { get; }

        int Length { get; }

        T this[int index] { get; set; }

        bool Check(int index);
        int Add(T data);

        //int AddId();

        void Remove(int index);
        void Clear();

        T[] GetAllDatas();

        T[] FindData(Seek<T> seek);
    }


}
