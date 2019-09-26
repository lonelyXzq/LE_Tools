using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.EventSystem
{
    public class Channel<T>:IChannel
    {
        public event EventHandler<T> Events;

        private int id;

        private string name;

        public int Id => id;

        public string Name => name;

        private readonly EventPool<T> eventPool;

        internal Channel(EventPool<T> eventPool)
        {
            this.eventPool = eventPool;
            this.id = -1;
        }

        public void Init(string name)
        {
            this.name = name;
        }

        public void Clear()
        {
            Events = null;
            name = null;
        }

        internal void SetId(int id)
        {
            this.id = id;
        }

        public void Fire(object sender, T e)
        {
            eventPool.AddEvent(new LE_Event<T>(id, sender, e));
            //Events?.Invoke(sender, e);
        }

        public void FireNow(object sender, T e)
        {
            Events?.Invoke(sender, e);
        }
    }
}
