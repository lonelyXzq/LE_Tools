using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class InstanceTests
    {
        [TestMethod]
        public void BaaseTest()
        {
            DateTime dateTime = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
            {
                //A.Instance.Add();//45
                B.Add();//43
            }
            DateTime d1 = DateTime.Now;
            Console.WriteLine((d1 - dateTime).TotalMilliseconds);
        }

        class A
        {
            int[] t=new int[10];
            public static A Instance = new A();

            public int Add()
            {
                return t[0];
            }
        }

        static class B
        {
            static int[] t = new int[10];

            public static int Add()
            {
                return t[0];
            }
        }
    }
}
