using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Listener
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class ListenTimeAttribute:Attribute
    {
        private readonly ListenChance listenChance;

        public ListenTimeAttribute(ListenChance listenChance)
        {
            this.listenChance = listenChance;
        }

        public ListenChance ListenChance => listenChance;
    }
}
