using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public interface IFsmState<T> where T : IFsmOwner
    {
        int Id { get; }

        string Name { get; }


        void ChangeTo(int id, T owner);

        void Active(FsmActiveChance fsmActiveChance, T owner);
    }
}
