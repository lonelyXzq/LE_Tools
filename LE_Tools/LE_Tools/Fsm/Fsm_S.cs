using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public static class Fsm_S<T> where T:IFsmOwner
    {
        private static IReadOnlyDictionary<string, int> fsmStates;

        private static IReadOnlyDictionary<int, IFsmAction<T>> actions;

        static Fsm_S()
        {
        }

        public static void Init()
        {
            fsmStates = FsmBuilder<T>.Builder.FsmStates;
            actions = FsmBuilder<T>.Builder.Actions;
        }


    }
}
