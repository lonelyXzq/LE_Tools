using System;

namespace LE_Tools.Fsm
{
    public interface IFsmAction<T> where T : IFsmOwner
    {
        int Mark { get; }

        event FsmEventHandler<T> Handler;

        void Activate(T e);
    }
}