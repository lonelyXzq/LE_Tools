using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LE_Tools.StructData.MemSystem
{
    public static class MemoryManager
    {
        private static List<IntPtr> mems = new List<IntPtr>();


        public static IntPtr GetMemory(int n)
        {
            unsafe
            {
                IntPtr t = Marshal.AllocHGlobal(n);
                return t;
            }
        }

        public static void Release(IntPtr intPtr)
        {
            Marshal.FreeHGlobal(intPtr);
        }
    }
}
