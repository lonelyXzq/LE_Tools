using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    static class Fsm_S<T> where T : IFsmOwner
    {
        private static IReadOnlyDictionary<string, int> fsmStates;

        private static IReadOnlyDictionary<int, IFsmAction<T>> actions;

        public static IReadOnlyDictionary<string, int> FsmStates => fsmStates;
        public static IReadOnlyDictionary<int, IFsmAction<T>> Actions => actions;

        public static int Count => count;
        public static int ActionCount => actionCount;

        private static int count;

        private static int actionCount;

        static Fsm_S()
        {
        }

        public static void Init()
        {
            if (fsmStates == null)
            {
                fsmStates = FsmBuilder<T>.Builder.FsmStates;
                count = fsmStates.Count;
                actions = FsmBuilder<T>.Builder.Actions;
                actionCount = actions.Count;
                FsmBuilder<T>.Release();
            }
        }

        public static int GetState(string name)
        {
            if (fsmStates.TryGetValue(name, out int id))
            {
                return id;
            }
            return -1;
        }

        public static IFsmAction<T> GetAction(int mark)
        {
            if (actions.TryGetValue(mark, out var action))
            {
                return action;
            }
            return null;
        }

        public static void Activate(T owner, int mark)
        {
            GetAction(mark)?.Activate(owner);
        }
    }
}
