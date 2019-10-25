using LE_Tools.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    public static class DataInfo<T> where T:struct,IData
    {
        private static readonly int id;

        private static readonly string name;

        private static readonly ISList<BN<T>> dataBlocks;

        static DataInfo()
        {
            id = IdManager.IdDeliverer.CreateId<IData, T>();
            name = typeof(T).Name;
            dataBlocks = new SteadyList<BN<T>>();
        }

        public static void Init()
        {
        }

        public static int Id => id;

        public static string Name => name;

        internal static ISList<BN<T>> DataBlocks => dataBlocks;
    }
}
