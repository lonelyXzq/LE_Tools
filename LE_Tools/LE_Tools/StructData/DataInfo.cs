using LE_Tools.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LE_Tools.StructData
{
    public static class DataInfo<T> where T:struct,IData
    {
        private static readonly int id;

        private static readonly string name;

        private static readonly ISList<BlockNode> dataBlocks;

        private static readonly int size;

        static DataInfo()
        {
            id = IdManager.IdDeliverer.CreateId<IData, T>();
            name = typeof(T).Name;
            unsafe
            {
                size = Marshal.SizeOf<T>();
            }
            dataBlocks = new SteadyList<BlockNode>();
        }

        public static void Init()
        {
        }

        public static int Id => id;

        public static string Name => name;

        internal static ISList<BlockNode> DataBlocks => dataBlocks;

        public static int Size => size;
    }
}
