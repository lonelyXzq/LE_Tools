using LE_Tools.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Tools.StructData
{
    public static class DataManager
    {
        private static int count;

        private static IBaseSList[] dataBlockManagers;

        public static int Count => count;

        internal static IBaseSList[] DataBlockManagers => dataBlockManagers;

        static DataManager()
        {

        }


        internal static void Register(Type[] types)
        {
            Type type1 = typeof(DataInfo<>);
            count = types.Length;
            dataBlockManagers = new IBaseSList[count];
            for (int i = 0; i < types.Length; i++)
            {
                //type1.MakeGenericType(types[i]).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                //   .Invoke(null, null);
                dataBlockManagers[i] = (IBaseSList)type1.MakeGenericType(types[i]).GetProperty("DataBlocks", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);

                LE_Log.Log.Info("DataRegister", "DataId: {0}  DataName: {1}", i, types[i].FullName);
            }
        }

        public static void Init()
        {
            if (dataBlockManagers == null)
            {
                var types = TypeManager.GetTypes(
                    t => t.GetInterfaces().Contains(typeof(IData)));
                Register(types);
            }
        }
    }
}
