using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{

    interface ISList<T>:IBaseSList
    {

        T this[int index] { get; set; }

        int Add(T data);

        T GetData(int id);

        T[] GetAllDatas();

        T[] FindData(Seek<T> seek);
    }


}
