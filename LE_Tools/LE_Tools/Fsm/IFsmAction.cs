using System;

namespace LE_Tools.Fsm
{
    public interface IFsmAction<T> where T : IFsmOwner
    {
        int From { get; }
        int Mark { get; }
        int To { get; }

        event FsmEventHandler<T> Handler;

        void Active(T e);
    }
}