using LE_Tools.EventSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.EventSystem
{
    [TestClass]
    public class EventPoolTests
    {
        [TestMethod]
        public void InitTests()
        {
            EventPool<int> eventPool = new EventPool<int>();
            var t = eventPool.CreateChannel("a");
            t.Events += Ac;
            t.FireNow(this, 5);
            Console.WriteLine(t.Name);
            Console.WriteLine(t.Id);
            t.Clear();
            t.FireNow(this, 4);
            t.Init("B");
            Console.WriteLine(t.Name);
            Console.WriteLine(t.Id);
            var ts = eventPool.FindChannels((a) =>a.Name=="B");
            Assert.AreEqual(ts[0].Id, 0);
            eventPool.RemoveChannel(t.Id);
            eventPool.RemoveChannel(t);


        }

        public void Ac(object o, int t)
        {
            Console.WriteLine(t);
        }
    }
}
