using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    class DataIndex
    {
        private readonly int blockSize;
        private int firtEmpty;
        private int lastPoint;
        private readonly int[] marks;
        private int count;
        public bool IsEmpty => count == 0;

        public bool IsFull => count == blockSize;

        public int Count => count;

        public DataIndex(int blockSize)
        {
            firtEmpty = 0;
            lastPoint = blockSize - 1;
            count = 0;
            marks = new int[blockSize];
            this.blockSize = blockSize;
            for (int i = 0; i < blockSize; i++)
            {
                marks[i] = i + 1;
            }
        }

        public bool this[int index]
        {
            get
            {
                return Check(index);
            }
        }

        public int AddData()
        {
            if (!IsFull)
            {
                int re = firtEmpty;
                if (count < blockSize - 1)
                {
                    firtEmpty = marks[re];
                }
                marks[re] = -1;
                count++;
                return re;
            }
            return -1;
        }

        public bool Check(int index)
        {
            if (index < 0 || index >= blockSize)
            {
                return false;
            }
            else if (marks[index] == -1)
            {
                return true;
            }
            return false;
        }

        public void RemoveData(int index)
        {
            if (Check(index))
            {

                marks[index] = -2;
                marks[lastPoint] = index;
                if (IsFull)
                {
                    marks[lastPoint] = -1;
                    firtEmpty = index;
                }
                lastPoint = index;
                count--;
            }
        }
    }
}
