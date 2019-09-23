using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    interface IBaseSList
    {
        /// <summary>
        /// 元素数目
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 当前链长度
        /// </summary>
        int Length { get; }

        bool Check(int index);

        void Remove(int index);
        void Clear();
    }
}
