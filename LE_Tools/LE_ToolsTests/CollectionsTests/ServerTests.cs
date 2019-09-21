using LE_Tools;
using LE_Tools.Collections;
using LE_Tools.EventSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LE_ToolsTests.CollectionsTests
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void BaseTest()
        {
            Server server = new Server(20, "testServer");
            server.SetAction(DoSomething);
            Console.WriteLine("2333");
            server.Start();
            Thread.Sleep(100);
            server.Stop();
        }

        //[EventAttach("das")]
        public void DoSomething()
        {
            Console.WriteLine("Do");
        }
    }
}
