using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class FsmAction<T> : IFsmAction<T> where T : IFsmOwner
    {
        private readonly int mark;

        internal FsmAction(int mark)
        {
            this.mark = mark;
        }

        public int Mark => mark;

        public event FsmEventHandler<T> Handler;

        public void Activate(T e)
        {
            Handler?.Invoke(e);
        }
    }
}
