using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    class FsmHelper<T> where T : IFsmOwner
    {
        private string state;
        private int st;

        private readonly Fsm<T> helper;

        private readonly T owner;

        public string State => state;

        public Fsm<T> InstanceFsm => helper;

        public T Owner => owner;

        public FsmHelper(string state, T owner)
        {
            this.state = state;
            this.helper = new Fsm<T>();
            this.st = helper.GetFsmState(state);
            this.owner = owner;
        }

        public void OnInit()
        {
            foreach (var item in Fsm_S<T>.FsmStates.Values)
            {
                helper.Activate(owner, Fsm<T>.CreateMark(item, FsmActiveChance.OnInit));
            }
            foreach (var item in helper.FsmStates.Values)
            {
                helper.Activate(owner, Fsm<T>.CreateMark(item, FsmActiveChance.OnInit));
            }
            helper.Activate(owner, Fsm<T>.CreateMark(st, FsmActiveChance.OnEnter));
        }

        public void Change(string toState)
        {
            int id = helper.GetFsmState(toState);
            if (id == -1)
            {
                //TODO:
                return;
            }
            helper.ChangeState(owner, st, id);
            st = id;
            state = toState;

        }

        public void OnUpdate()
        {
            if (st != -1)
            {
                helper.Activate(owner, Fsm<T>.CreateMark(st, FsmActiveChance.OnUpdate));
            }
        }

        public void Ondestory()
        {
            helper.Activate(owner, Fsm<T>.CreateMark(st, FsmActiveChance.OnLeave));
            foreach (var item in Fsm_S<T>.FsmStates.Values)
            {
                helper.Activate(owner, Fsm<T>.CreateMark(item, FsmActiveChance.OnDestory));
            }
            foreach (var item in helper.FsmStates.Values)
            {
                helper.Activate(owner, Fsm<T>.CreateMark(item, FsmActiveChance.OnDestory));
            }
        }
    }
}
