using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Fsm
{
    public class Fsm<T> where T : IFsmOwner
    {
        private readonly int id;
        private readonly string name;

        public Fsm(string name)
        {
            this.name = name;
        }

        public int Id => id;

        public string Name => name;
    }
}
