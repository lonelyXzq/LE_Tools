using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    class MappingArray : IMappingArray
    {
        private readonly int[] datas;
        private readonly int size;

        public MappingArray(int size)
        {
            datas = new int[size];
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                datas[i] = -1;
            }
        }

        public void Set(int i, int data)
        {
            if (i < 0 || i >= size)
            {
                return;
            }
            datas[i] = data;
        }

        public int Get(int i)
        {
            if (i < 0 || i >= size)
            {
                return -1;
            }
            return datas[i];
        }
    }
}
