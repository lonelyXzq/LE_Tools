using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Command
{
    public struct CommandData<T> where T : struct, IData
    {
        private readonly int fromId;
        private readonly int entityId;
        private T data;
        private readonly int operatorId;

        public int FromId => fromId;

        public int EntityId => entityId;

        public int OperatorId => operatorId;

        public T Data { get => data; set => data = value; }

        public CommandData(int fromId, int entityId, T data, int operatorId)
        {
            this.fromId = fromId;
            this.entityId = entityId;
            this.data = data;
            this.operatorId = operatorId;
        }
    }
}
