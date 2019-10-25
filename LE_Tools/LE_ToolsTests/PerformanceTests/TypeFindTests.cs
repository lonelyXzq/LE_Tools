using LE_Tools;
using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class TypeFindTests
    {
        [TestMethod]
        public void BaseTest()
        {
            var t = TypeManager.GetTypes((a) => (a.GetInterfaces().Contains(typeof(IData))));
            DateTime d = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                var t1 = TypeManager.GetTypes((a) => (a.GetInterfaces().Contains(typeof(IData))));
            }
            DateTime d2 = DateTime.Now;
            Console.WriteLine((d2 - d).TotalMilliseconds);
            TA tA = new TA();
            Console.WriteLine(tA.a);
        }

        class TA
        {
            public int a;

            public TA(int a = 73)
            {
                this.a = a;
            }
        }
    }
}
