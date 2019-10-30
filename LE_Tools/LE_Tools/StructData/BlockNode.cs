using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    unsafe class BlockNode
    {
        private readonly IntPtr intPtr;
        private readonly int size;
        private readonly int number;

        public BlockNode(int size, int number)
        {
            intPtr = MemSystem.MemoryManager.GetMemory(size * number);
            this.size = size;
            this.number = number;
        }

        public Span<T> CreateSpan<T>() where T : struct, IData
        {
            if (DataInfo<T>.Size != size)
            {
                LE_Log.Log.Exception(new Exception(), "invalid type exception", "can not create span of type: {0}", typeof(T).FullName);
            }
            return new Span<T>(intPtr.ToPointer(), number);
        }

        public void Release()
        {
            MemSystem.MemoryManager.Release(intPtr);
        }
    }

}
