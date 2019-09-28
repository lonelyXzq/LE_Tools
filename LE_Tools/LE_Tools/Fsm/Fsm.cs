using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class Fsm<T> where T : IFsmOwner
    {
        private static readonly IReadOnlyDictionary<string, int> fsmStates = new Dictionary<string, int>();

        private readonly Dictionary<int, IFsmAction<T>> actions;

        private int count;

        private bool mark;

        public int Count => count;

        private static readonly Fsm<T> instance = new Fsm<T>(true);

        public static Fsm<T> Instance => instance;

        public static IReadOnlyDictionary<string, int> FsmStates => fsmStates;

        public Fsm()
        {
            mark = false;
            actions = new Dictionary<int, IFsmAction<T>>();
        }

        private Fsm(bool mark)
        {
            this.mark = mark;
            actions = new Dictionary<int, IFsmAction<T>>();
        }

        public static void BuildState(params string[] names)
        {
            var t = (Dictionary<string, int>)fsmStates;
            for (int i = 0; i < names.Length; i++)
            {
                t.Add(names[i], i + 1);
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
            AddAction(new FsmAction<T>(now, next, 7), handler);
        }

        public void AddAction(string state, FsmActiveChance chance, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(state);
            if (now == -1)
            {
                return;
            }
            AddAction(new FsmAction<T>(now, 0, (int)chance), handler);
        }

        private void AddAction(FsmAction<T> fsmAction, FsmEventHandler<T> handler)
        {
            if (actions.ContainsKey(fsmAction.Mark))
            {
                actions[fsmAction.Mark].Handler += handler;
            }
            else
            {
                fsmAction.Handler += handler;
                actions.Add(fsmAction.Mark, fsmAction);
            }
        }

        public IFsmAction<T> GetAction(int mark)
        {
            if (actions.TryGetValue(mark, out var fsmAction))
            {
                return fsmAction;
            }
            return null;
        }

        public static int GetFsmState(string state)
        {
            if (fsmStates.TryGetValue(state, out int fsm))
            {
                return fsm;
            }
            LE_Log.Log.Error("FsmStateError", "FsmState[ownerType: {0} ,name: {1} ] does not exists"
                , typeof(T).FullName, state);
            return -1;
        }

        public void Active(T owner, string nowState, FsmActiveChance chance)
        {
            int now = GetFsmState(nowState);
            int ch = (int)chance;
            if (!mark)
            {
                instance.Active(owner, now, ch);
            }
            Active(owner, now, ch);
        }

        private void Active(T owner,int now,int chance)
        {
            if (now == -1)
            {
                return;
            }
            if (actions.TryGetValue((now << 3) + chance, out IFsmAction<T> a))
            {
                a.Active(owner);
            }
        }

        public void ChangeState(T owner, string nowState, string toState)
        {
            int now = GetFsmState(nowState);
            int to = GetFsmState(toState);
            if (!mark)
            {
                instance.Change(owner, now, to);
            }
            Change(owner, now, to);
        }

        private void Change(T owner, int now, int next)
        {
            if (now == -1 || next == -1)
            {
                return;
            }
            int mark = (next << 17) + (now << 3);
            if (actions.TryGetValue((now << 3) + 3, out IFsmAction<T> a1))
            {
                a1.Active(owner);
            }
            if (actions.TryGetValue(mark + 7, out IFsmAction<T> a))
            {
                a.Active(owner);
            }
            if (actions.TryGetValue((next << 3) + 1, out IFsmAction<T> a2))
            {
                a2.Active(owner);
            }
        }
    }
}
