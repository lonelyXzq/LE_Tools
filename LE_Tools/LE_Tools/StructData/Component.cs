using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LE_Tools.Collections;

namespace LE_Tools.StructData
{
    class Component
    {
        private readonly DataIndex dataIndex;
        private readonly ComponentType componentType;
        public static int BlockSize;
        private readonly IntPtr[] nodes;

        public Component(ComponentType componentType)
        {
            dataIndex = new DataIndex(BlockSize);
            this.componentType = componentType;
            nodes = new IntPtr[componentType.DataCount];
        }

        public void SetData<T>(int id,T data) where T:struct,IData
        {
            int m = componentType.MappingArray.Get(DataInfo<T>.Id);
            var t = nodes[m] + id;
            Marshal.StructureToPtr<T>(data, t, false);
        }

        public T GetData<T>(int id) where T : struct, IData
        {
            int m = componentType.MappingArray.Get(DataInfo<T>.Id);
            var t = nodes[m] + id;
            return Marshal.PtrToStructure<T>(t);
        }

    }
}
