using LE_Tools.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Tools.StructData
{
    class ComponentType
    {
        private readonly string name;
        private readonly int id;
        private readonly IEntityType entityType;
        private readonly BitArray info;
        private readonly IMappingArray mappingArray;
        private readonly int dataCount;

        public ComponentType(IEntityType entityType)
        {
            Type type = entityType.GetType();
            name = type.FullName;
            info = new BitArray(DataManager.Count);
            mappingArray = new MappingArray(DataManager.Count);
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
            int k = 0;
            for (int i = 0; i < DataManager.Count; i++)
            {
                if (info[i])
                {
                    mappingArray.Set(i, k);
                    k++;
                }
            }
            dataCount = k;
            id = IdManager.IdDeliverer.CreateId<IEntityType>(type);
            LE_Log.Log.Info("TypeRegister", "TypeId: {0} TypeName: {1}", id, name);
            this.entityType = entityType;
        }

        public string Name => name;

        public int Id => id;

        public BitArray Info => info;

        public IEntityType EntityType => entityType;

        public int DataCount => dataCount;

        internal IMappingArray MappingArray => mappingArray;
    }
}
