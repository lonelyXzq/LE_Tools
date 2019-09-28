using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class FsmBuilder<T> where T:IFsmOwner
    {
        private static FsmBuilder<T> builder = new FsmBuilder<T>();

        public static FsmBuilder<T> Builder => builder;

        public Dictionary<string, int> FsmStates => fsmStates;

        public Dictionary<int, IFsmAction<T>> Actions => actions;

        private readonly Dictionary<string,int> fsmStates;

        private readonly Dictionary<int, IFsmAction<T>> actions;

        private FsmBuilder()
        {
            fsmStates = new Dictionary<string, int>();
            actions = new Dictionary<int, IFsmAction<T>>();
        }

        public void BuildState(params string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                fsmStates.Add(names[i], i + 1);
            }
        }

        public int GetFsmState(string state)
        {
            if (fsmStates.TryGetValue(state, out int fsm))
            {
                return fsm;
            }
            LE_Log.Log.Error("FsmStateError", "FsmState[ownerType: {0} ,name: {1} ] does not exists"
                , typeof(T).FullName, state);
            return -1;
        }

        public void AddAction(string from, string to, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(from);
            int next = GetFsmState(to);
            if (now == -1 || next == -1)
            {

                return;
            }
            AddAction(now, next, Fsm<T>.CreateMark(now, next, 7), handler);
        }

        public void AddAction(string state, FsmActiveChance chance, FsmEventHandler<T> handler)
        {
            int now = GetFsmState(state);
            if (now == -1)
            {
                return;
            }
            AddAction(now, 0, Fsm<T>.CreateMark(now, chance), handler);
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




    public static void Release()
        {
            builder = null;
        }

    }

}
