using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Tools.StructData
{
    class Type_E
    {
        private readonly string name;
        private readonly int id;

        private readonly IEntityType entityType;

        private readonly BitArray info;

        public Type_E(IEntityType entityType)
        {
            Type type = entityType.GetType();
            name = type.FullName;
            info = new BitArray(DataManager.Count);
            Type dataType = typeof(DataInfo<>);
            var fieldInfos = type.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Type t = fieldInfos[i].FieldType;
                if ((!t.IsClass) && t.GetInterfaces().Contains(typeof(IData)))
                {
                    int index = (int)dataType.MakeGenericType(t).GetField("id", BindingFlags.NonPublic | BindingFlags.Static)
                        .GetValue(null);
                    info.Set(index, true);
                }
            }
            id = IdManager.IdDeliverer.CreateId<IEntityType>(type);
            LE_Log.Log.Info("TypeRegister", "TypeId: {0} TypeName: {1}", id, name);
            this.entityType = entityType;
        }

        public string Name => name;

        public int Id => id;

        public BitArray Info => info;

        public IEntityType EntityType => entityType;
    }
}
