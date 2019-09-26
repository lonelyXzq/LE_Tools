using LE_Tools.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Tools.EventSystem
{
    class EventPool<T>
    {
        private readonly ISList<Channel<T>> channels;

        private readonly ConcurrentQueue<LE_Event<T>> events;

        private string name;

        private int mark;

        public string Name { get => name; set => name = value; }

        public EventPool(string name="default")
        {

            channels = new SteadyList<Channel<T>>();
            events = new ConcurrentQueue<LE_Event<T>>();
            this.name = name;
            mark = 0;
            //ids = new Dictionary<string, int>();
        }

        internal void AddEvent(LE_Event<T> e)
        {
            events.Enqueue(e);
        }

        public Channel<T> CreateChannel(string name)
        {
            Channel<T> channel = new Channel<T>(this);
            channel.Init(name);
            int id = channels.Add(channel);
            channel.SetId(id);
            return channel;
        }

        public void Update()
        {
            int n = events.Count;
            int i = 0;
            while (events.TryDequeue(out LE_Event<T> e))
            {
                channels[e.ChannelId].FireNow(e.Sender, e.E);
                i++;
                if (i == n)
                {
                    return;
                }
            }
        }

        public Channel<T> GetChannel(int id)
        {
            return channels.GetData(id);
        }

        public Channel<T>[] FindChannels(Seek<Channel<T>> seek)
        {
            return channels.FindData(seek);
        }

        public void RemoveChannel(int id)
        {
            channels.Remove(id);
        }

        public void RemoveChannel(Channel<T> channel)
        {
            RemoveChannel(channel.Id);
        }

    }
}
