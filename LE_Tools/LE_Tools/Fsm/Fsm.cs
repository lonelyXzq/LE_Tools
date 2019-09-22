using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class Fsm<T> where T : IFsmOwner
    {
        private readonly IReadOnlyDictionary<string, FsmState<T>> fsmStates;

        public Fsm(Dictionary<string, FsmState<T>> states)
        {
            fsmStates = states;
        }

        public FsmState<T> GetFsmState(string state)
        {
            if (fsmStates.TryGetValue(state, out FsmState<T> fsm))
            {
                return fsm;
            }
            LE_Log.Log.Error("FsmStateError", "FsmState[ownerType: {0} ,name: {1} ] does not exists"
                , typeof(T).FullName, state);
            return null;

        }

        public void ChangeState(T owner, string nowState, string toState)
        {
            var now = GetFsmState(nowState);
            var to = GetFsmState(toState);
            if (now == null || to == null)
            {
                return;
            }
            now.Active(FsmActiveChance.OnLeave, owner);
            now.ChangeTo(to.Id, owner);
            to.Active(FsmActiveChance.OnEnter, owner);
        }
    }
}
