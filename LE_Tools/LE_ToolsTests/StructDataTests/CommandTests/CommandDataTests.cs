using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LE_Tools.StructData.Command;
using LE_Tools.StructData;

namespace LE_ToolsTests.StructDataTests.CommandTests
{
    [TestClass]
    public class CommandDataTests
    {
        [TestMethod]
        public void CommandTransportTest()
        {
            CommandData<A> command = new CommandData<A>(1, 0, new A(3), 0);
        }

        struct A : IData
        {
            public int data;

            public A(int data)
            {
                this.data = data;
            }
        }
    }
}
