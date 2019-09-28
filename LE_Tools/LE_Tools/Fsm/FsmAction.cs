using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class FsmAction<T> : IFsmAction<T> where T : IFsmOwner
    {
        private readonly int from;
        private readonly int to;
        private readonly int mark;

        internal FsmAction(int from, int to, int mark)
        {
            //if ((from > (1 << 14) - 1) || (to > (1 << 14) - 1) || (state > (1 << 3) - 1))
            //{
            //    return;
            //}
            this.from = from;
            this.to = to;
            this.mark = mark;
        }

        public int From => from;

        public int To => to;

        public int Mark => mark;

        public event FsmEventHandler<T> Handler;

        public void Activate(T e)
        {
            Handler?.Invoke(e);
        }
    }
}
