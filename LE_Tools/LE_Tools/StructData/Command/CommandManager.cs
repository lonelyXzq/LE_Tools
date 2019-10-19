using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    static class CommandManager<T> where T : struct, IData
    {
        public static CommandExecute<T> GetCommand(int id)
        {
            return null;
        }
    }
}
