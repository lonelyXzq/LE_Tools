using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    class CommandManager<T> where T : struct, IData
    {
        public event CommandOperator<T> Command;

        public void ExecuteCommand(ref CommandData<T> data)
        {
            Command?.Invoke(ref data);
        }

        public static void Execute(ref CommandData<T> data)
        {
            if (data.OperatorId == 1)
            {
                //setdate
            }
        }
    }
}
