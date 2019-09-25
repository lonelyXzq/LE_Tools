using LE_Tools.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.EventSystem
{
    class EventPool<T>
    {
        private readonly ISList<Channel<T>> channels;
        //private readonly Dictionary<string, int> ids;

        public EventPool()
        {
            channels = new SteadyList<Channel<T>>();
            //ids = new Dictionary<string, int>();
        }

        public Channel<T> CreateChannel(string name)
        {
            Channel<T> channel = new Channel<T>(this);
            channel.Init(name);
            int id = channels.Add(channel);
            channel.SetId(id);
            return channel;
        }

        public Channel<T> GetChannel(int id)
        {
            return channels.GetData(id);
        }

        public Channel<T>[] FindChannels(Seek<Channel<T>> seek)
        {
            return channels.FindData(seek);
        }

        //public void RemoveChannel(string name)
        //{
        //    if (ids.TryGetValue(name, out int id))
        //    {
        //        RemoveChannel(id);
        //    }
        //    else
        //    {

        //        LE_Log.Log.Error("Channel error", "Channel:[name: {0}] does not exists", name);
        //    }
        //}

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
