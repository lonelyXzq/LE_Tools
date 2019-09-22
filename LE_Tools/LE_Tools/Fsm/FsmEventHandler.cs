using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    /// <summary>
    /// 响应函数
    /// </summary>
    /// <typeparam name="T">
    /// 持有者类型
    /// </typeparam>
    /// <param name="owner">
    /// 持有者
    /// </param>
    public delegate void FsmEventHandler<T>(T owner) where T : IFsmOwner;
}
