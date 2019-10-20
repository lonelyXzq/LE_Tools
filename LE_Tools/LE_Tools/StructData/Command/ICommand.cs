using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    public delegate void CommandExecute<T>(int id, ref T data) where T : struct, IData;
    public delegate void CommandOperator<T>(ref CommandData<T> data) where T : struct, IData;
    interface ICommand<T> where T:struct,IData
    {
        void Execute();
    }
}
