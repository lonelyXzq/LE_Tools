using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    struct CommandData<T> where T : struct, IData
    {
        private readonly int fromId;
        private readonly int entityId;
        private T data;
        private readonly int typeId;

        public int FromId => fromId;

        public int EntityId => entityId;

        public T Data => data;

        public int TypeId => typeId;

        public CommandData(int fromId, int entityId, T data, int typeId)
        {
            this.fromId = fromId;
            this.entityId = entityId;
            this.data = data;
            this.typeId = typeId;
        }

        public void Execute()
        {
            CommandExecute<T> command=CommandManager<T>.GetCommand(typeId);
            command?.Invoke(entityId, ref data);
        }
    }
}
