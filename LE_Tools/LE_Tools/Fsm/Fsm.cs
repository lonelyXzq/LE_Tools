using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
     class Fsm<T> where T : IFsmOwner
    {
        private readonly Dictionary<string, int> fsmStates;

        private readonly Dictionary<int, IFsmAction<T>> actions;

        public IReadOnlyDictionary<string, int> FsmStates => fsmStates;

        public IReadOnlyDictionary<int, IFsmAction<T>> Actions => actions;

        public int StateCount => fsmStates.Count;

        public int ActionCount => actions.Count;


        public static int CreateMark(int from, int to, int state)
        {
            return (to << 17) + (from << 3) + state;
        }

        public static int CreateMark(int now, FsmActiveChance chance)
        {
            return (now << 3) + (int)chance;
        }

        public Fsm()
        {
            Fsm_S<T>.Init();
            actions = new Dictionary<int, IFsmAction<T>>();
            fsmStates = new Dictionary<string, int>();
        }


        public void AddState(params string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                fsmStates.Add(names[i], i + 1 + Fsm_S<T>.Count);
            }
        }


        public void AddAction(string from, string to, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(from);
            int next = GetFsmState(to);
            if (now == -1 || next == -1)
            {
                return;
            }
            AddAction(CreateMark(now, next, 7), handler);
        }

        public void AddAction(string state, FsmActiveChance chance, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(state);
            if (now == -1)
            {
                return;
            }
            AddAction(CreateMark(now, chance), handler);
        }

        private void AddAction(int mark, FsmEventHandler<T> handler)
        {
            if (actions.ContainsKey(mark))
            {
                actions[mark].Handler += handler;
            }
            else
            {
                IFsmAction<T> fsmAction = new FsmAction<T>(mark);
                fsmAction.Handler += handler;
                actions.Add(fsmAction.Mark, fsmAction);
            }
        }

        public IFsmAction<T> GetAction(int mark)
        {
            var t = Fsm_S<T>.GetAction(mark);
            if (t != null)
            {
                return t;
            }
            if (actions.TryGetValue(mark, out var fsmAction))
            {
                return fsmAction;
            }
            return null;
        }

        public int GetFsmState(string state)
        {
            int id = Fsm_S<T>.GetState(state);
            if (id != -1)
            {
                return id;
            }
            if (fsmStates.TryGetValue(state, out int fsm))
            {
                return fsm;
            }
            LE_Log.Log.Error("FsmStateError", "FsmState[ownerType: {0} ,name: {1} ] does not exists"
                , typeof(T).FullName, state);
            return -1;
        }

        internal int GetMark(string from, string to, int state)
        {
            int now = GetFsmState(from);
            int next = GetFsmState(to);
            if (now == -1 || next == -1)
            {

                return -1;
            }
            return CreateMark(now, next, state);
        }

        internal int GetMark(string state, FsmActiveChance chance)
        {
            int st = GetFsmState(state);
            if (st == -1)
            {

                return -1;
            }
            return CreateMark(st, chance);

        }

        internal void ChangeState(T owner, int now, int next)
        {
            //TODO:
            Activate(owner, (now << 3) + 3);
            Activate(owner, (next << 17) + (now << 3) + 7);
            Activate(owner, (next << 3) + 1);
        }

        internal void Activate(T owner, int mark)
        {
            Fsm_S<T>.Activate(owner, mark);
            if (actions.TryGetValue(mark, out var action))
            {
                action.Activate(owner);
            }
            else
            {
                //TODO: 
            }
        }
    }
}
