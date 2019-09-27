using LE_Tools.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.CollectionsTests
{
    [TestClass]
    public class SafetyListTests
    {
        class A
        {
            public int a;

            public A(int a)
            {
                this.a = a;
            }
        }
        private SafetySList<A> list = new SafetySList<A>();

        [TestMethod]
        public void AddTest()
        {
            list.Clear();
            list.Add(new A(0));
            list.Add(new A(1));
            Assert.AreEqual(2, list.Count);
            Console.WriteLine(list[0].a);
            Console.WriteLine(list[1].a);
            Console.WriteLine(list.GetData(0).a);
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Clear();
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(2));
            list.Add(new A(3));
            list.Remove(1);
            list.Remove(1);
            list.Remove(-1);
            Assert.AreNotEqual(list.Check(1), true);
            int n = 0;
            var t = list.GetAllDatas();
            for (int i = 0; i < t.Length; i++)
            {
                n += t[i].a + 1;
                Console.WriteLine(t[i].a);
            }
            Assert.AreEqual(8, n);
        }

        [TestMethod]
        public void FindTest()
        {
            list.Clear();
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(1));
            list.Add(new A(3));
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(1));
            list.Add(new A(3));
            var t = list.FindData((a)=>a.a==1);
            for (int i = 0; i < t.Length; i++)
            {
                Assert.AreEqual(1,t[i].a);
            }
            Assert.AreEqual(4, t.Length);
        }

        [TestMethod]
        public void ThreadTest()
        {
            list.Clear();
            Parallel.For(0, 20, (i) => list.Add(new A(i)));

            Assert.AreEqual(20, list.Count);
        }
    }
}
