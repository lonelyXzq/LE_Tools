using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class SpanTests
    {
        [TestMethod]
        public void BuildTest()
        {
            unsafe
            {
                Console.WriteLine(sizeof(A));
            }
        }
        unsafe struct A
        {
            public int a;
            public fixed int t[10];

            public A(int a)
            {
                this.a = a;
            }
        }
    }
}
