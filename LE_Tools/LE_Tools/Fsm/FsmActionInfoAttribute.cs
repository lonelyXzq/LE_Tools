using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class FsmActionInfoAttribute:Attribute
    {
        private readonly string name;
        private readonly string toName;
        private readonly FsmActiveChance chance;
        private readonly bool mark;

        public FsmActionInfoAttribute(string name, FsmActiveChance chance)
        {
            this.name = name;
            this.chance = chance;
            this.toName = null;
            mark = false;
        }

        public FsmActionInfoAttribute(string name, string toName)
        {
            this.name = name;
            this.toName = toName;
            this.chance = FsmActiveChance.OnLeave;
            mark = true;
        }

        public string Name => name;

        public FsmActiveChance Chance => chance;

        public string ToName => toName;

        public bool Mark => mark;
    }
}
