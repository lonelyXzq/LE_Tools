using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    [Serializable]
    public delegate void CommandExecute<T>(int id, ref T data) where T : struct, IData;
    interface ICommand<T> where T:struct,IData
    {

        void Execute();
    }
}
