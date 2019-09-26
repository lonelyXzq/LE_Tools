using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.EventSystem
{
    class LE_Event<T>
    {
        private readonly int channelId;
        private readonly object sender;
        private readonly T e;

        public LE_Event(int channelId, object sender, T e)
        {
            this.channelId = channelId;
            this.sender = sender;
            this.e = e;
        }

        public int ChannelId => channelId;

        public object Sender => sender;

        public T E => e;
    }
}
