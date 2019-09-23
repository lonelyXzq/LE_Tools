using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    class BlockNode<T> where T:struct,IData
    {
        private readonly T[] datas;

        public BlockNode()
        {
            this.datas = new T[BlockInfo.BlockSize];
        }
    }
}
