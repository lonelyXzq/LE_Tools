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
        private readonly Type type;

        public FsmActionInfoAttribute(string name, FsmActiveChance chance, Type type)
        {
            this.name = name;
            this.chance = chance;
            this.toName = null;
            mark = false;
            this.type = type;
        }

        public FsmActionInfoAttribute(string name, string toName, Type type)
        {
            this.name = name;
            this.toName = toName;
            this.chance = FsmActiveChance.OnLeave;
            mark = true;
            this.type = type;
        }

        public string Name => name;

        public FsmActiveChance Chance => chance;

        public string ToName => toName;

        public bool Mark => mark;

        public Type Type => type;
    }
}
