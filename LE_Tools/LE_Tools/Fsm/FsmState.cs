using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class FsmState<T> where T:IFsmOwner
    {
        private readonly int id;
        private readonly string name;
        private readonly FsmEventHandler<T>[] fsmEvents;
        private FsmEventHandler<T>[] changeEvents;

        public FsmState(string name, int id)
        {
            this.name = name;
            fsmEvents = new FsmEventHandler<T>[5];
            this.id = id;
        }


        public int Id => id;

        public string Name => name;

        internal void SetChanges(FsmEventHandler<T>[] fsmEventHandlers)
        {
            this.changeEvents = fsmEventHandlers;
        }

        internal void SubscribeChange(int id,FsmEventHandler<T> fsmEventHandler)
        {

            if (changeEvents[id] == null)
            {
                changeEvents[id] = fsmEventHandler;
            }
            else
            {
                changeEvents[id] += fsmEventHandler;
            }
        }

        internal void Subscribe(FsmActiveChance fsmActiveChance,FsmEventHandler<T> fsmEvent)
        {
            int id = (int)fsmActiveChance;
            if (fsmEvents[id] == null)
            {
                fsmEvents[id] = fsmEvent;
            }
            else
            {
                fsmEvents[id] += fsmEvent;
            }
        }

        public void ChangeTo(int id,T owner)
        {
            changeEvents[id]?.Invoke(owner);
        }

        public void Active(FsmActiveChance fsmActiveChance,T owner)
        {
            int id = (int)fsmActiveChance;
            fsmEvents[id]?.Invoke(owner);
        }
    }
}
