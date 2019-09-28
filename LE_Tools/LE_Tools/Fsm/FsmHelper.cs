using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    class FsmHelper<T> where T : IFsmOwner
    {
        private string state;

        private readonly Fsm<T> helper;

        private readonly T owner;

        public string State => state;

        public Fsm<T> Helper => helper;

        public T Owner => owner;

        public FsmHelper(string state, T owner)
        {
            this.state = state;
            this.helper = new Fsm<T>();
            this.owner = owner;
        }

        public void OnInit()
        {
            foreach (var item in Fsm<T>.FsmStates.Keys)
            {
                helper.Active(owner, item, FsmActiveChance.OnInit);
            }
            helper.Active(owner, state, FsmActiveChance.OnEnter);
        }

        public void Change(string toState)
        {
            helper.ChangeState(owner, state, toState);
            state = toState;
        }

        public void OnUpdate()
        {
            helper.Active(owner, state,FsmActiveChance.OnUpdate);
        }

        public void Ondestory()
        {
            helper.Active(owner, state, FsmActiveChance.OnLeave);
            foreach (var item in Fsm<T>.FsmStates.Keys)
            {
                helper.Active(owner, item, FsmActiveChance.OnDestory);
            }

        }
    }
}
