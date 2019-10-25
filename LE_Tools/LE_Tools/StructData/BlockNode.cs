using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    unsafe ref struct BlockNode<T> where T:struct,IData
    {
        private readonly Span<T> datas;
        private readonly IntPtr intPtr;

        public BlockNode(int n)
        {
            intPtr = MemSystem.MemoryManager.GetMemory(n);
            datas = new Span<T>(intPtr.ToPointer(), n);
        }

        public Span<T> Datas => datas;

        public void Release()
        {
            MemSystem.MemoryManager.Release(intPtr);
        }
    }

    public class BN<T> where T : struct, IData
    {
        
    }
}
