using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LE_Tools.StructData
{
    static class EntityTypeManager
    {
        private static Type_E[] type_Es;

        private static int count;

        public static int Count => count;

        public static Type_E[] Type_Es => type_Es;

        public static void Init()
        {
            if (type_Es == null)
            {
                var types = TypeManager.GetTypes(t => t.GetInterfaces().Contains(typeof(IEntityType)));
                Register(types);
            }
        }

        internal static void Register(Type[] types)
        {
            count = types.Length;
            type_Es = new Type_E[count];
            for (int i = 0; i < count; i++)
            {
                type_Es[i] = new Type_E((IEntityType)TypeManager.CreateInstance(types[i]));
            }
        }
    }
}
