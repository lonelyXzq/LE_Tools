using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.EventSystem
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    class EventAttachAttribute: Attribute
    {
        private readonly string name;

        public EventAttachAttribute(string name)
        {
            this.name = name;
            


        }

        public string Name => name;
    }
}
