using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Listener
{
    delegate void ListenAction<T>(int id, ref T data);

    public interface IListener<T> where T : IData
    {
        void Execute(int id, ref T data);
    }
}
