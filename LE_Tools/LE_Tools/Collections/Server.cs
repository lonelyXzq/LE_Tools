using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Tools.Collections
{
    class Server
    {
        private DateTime dataTime;
        private Thread thread;
        private AutoResetEvent exitEvent;
        private System.Action action;

        private readonly int delayTime;

        private readonly string name;

        public int DelayTime => delayTime;

        public string Name => name;

        public Server(int delayTime, string name)
        {
            this.delayTime = delayTime;
            this.name = name;
            thread = new Thread(OnUpdate);
            exitEvent = new AutoResetEvent(false);
        }

        public void SetAction(System.Action action)
        {
            this.action = action;
        }

        public void Start()
        {
            LE_Log.Log.Info("Server state change", "server : {0} start!", name);
            thread.Start();
        }

        public void Stop()
        {
            exitEvent.Set();
            thread.Join();
            LE_Log.Log.Info("Server state change", "server : {0} stop!", name);
        }

        private void OnUpdate()
        {
            while (true)
            {
                dataTime = DateTime.Now;
                action?.Invoke();
                int t = (int)(DateTime.Now - dataTime).TotalMilliseconds;
                //Console.WriteLine("----------------------------------{0}", t);
                if (t < DelayTime)
                {
                    if (exitEvent.WaitOne(DelayTime - t))
                    {
                        break;
                    }
                }
            }

        }
    }
}
