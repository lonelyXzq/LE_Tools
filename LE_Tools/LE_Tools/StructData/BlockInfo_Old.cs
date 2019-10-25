using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    public class BlockInfo
    {
        public static int BlockSizePow = 6;

        public static int BlockSize = 1 << BlockSizePow;

        private readonly DataIndex dataIndex;

        private readonly int blockId;

        public BlockInfo(int blockId)
        {
            dataIndex = new DataIndex(BlockSize);
            
        }

        public int BlockId => blockId;

        internal DataIndex DataIndex => dataIndex;
    }

    public class BlockInfo_Old
    {
        public static int BlockSizePow = 6;

        public static int BlockSize = 1 << BlockSizePow;


        private readonly int entityBlockId;

        private readonly int[] datas;

        private int firtEmpty;
        private int lastPoint;

        private readonly int[] marks;

        private int count;

        public bool IsEmpty => count == 0;

        public bool IsFull => count == BlockSize;

        public int Count => count;

        public BlockInfo_Old(int entityBlockId, int[] datas)
        {
            this.entityBlockId = entityBlockId;
            this.datas = datas;
            this.firtEmpty = 0;
            this.lastPoint = BlockSize - 1;
            count = 0;
            this.marks = new int[BlockSize];
            for (int i = 0; i < BlockSize; i++)
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
                if (count < BlockSize - 1)
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
            if (index < 0 || index >= BlockSize)
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

        public int EntityBlockId => entityBlockId;

        /// <summary>
        /// 各数据块编号
        /// </summary>
        public int[] BlockDatas => datas;

        public int[] Marks => marks;
    }
}
