using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class Fsm<T> where T : IFsmOwner
    {
        private readonly Dictionary<string, int> fsmStates = new Dictionary<string, int>();

        private readonly Dictionary<int, IFsmAction<T>> actions;

        public IReadOnlyDictionary<string, int> FsmStates => fsmStates;

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
            AddAction(now, next, CreateMark(now, next, 7), handler);
        }

        public void AddAction(string state, FsmActiveChance chance, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(state);
            if (now == -1)
            {
                return;
            }
            AddAction(now, 0, CreateMark(now, chance), handler);
        }

        private void AddAction(int from, int to, int mark, FsmEventHandler<T> handler)
        {
            if (actions.ContainsKey(mark))
            {
                actions[mark].Handler += handler;
            }
            else
            {
                FsmAction<T> fsmAction = new FsmAction<T>(from, to, mark);
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

        public void ChangeState(T owner, string nowState, string toState)
        {
            int now = GetFsmState(nowState);
            int next = GetFsmState(toState);
            if (now == -1 || next == -1)
            {
                return;
            }
            //TODO:
            Activate(owner, (now << 3) + 3);
            Activate(owner, (next << 17) + (now << 3) + 7);
            Activate(owner, (next << 3) + 1);
        }

        public void Activate(T owner, string nowState, FsmActiveChance chance)
        {
            int now = GetFsmState(nowState);
            if (now == -1)
            {
                return;
            }
            Activate(owner, CreateMark(now, chance));
        }

        private void Activate(T owner, int mark)
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
