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
    public class SListTests
    {
        private ISList<A> list = new SteadyList<A>();

        public void Init()
        {
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(2));
            list.Add(new A(3));
            list.Add(new A(4));
            list.Add(new A(5));
            list.Add(new A(6));
            list.Add(new A(7));
            list.Remove(0);
            list.Remove(3);
            list.Remove(6);
        }

        [TestMethod]
        public void AddTest()
        {
            Init();
            Assert.AreEqual(0, list.Add(new A(8)));
            Assert.AreEqual(3, list.Add(new A(9)));
            Assert.AreEqual(6, list.Add(new A(10)));
            Assert.AreEqual(8, list.Add(new A(11)));
            Assert.AreEqual(9, list.Add(new A(8)));
            Assert.AreEqual(10, list.Add(new A(9)));
            Assert.AreEqual(11, list.Add(new A(10)));
            Assert.AreEqual(12, list.Add(new A(11)));
        }

        [TestMethod]
        public void RomveTest()
        {
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(2));
            list.Add(new A(3));
            list.Add(new A(4));
            list.Add(new A(5));
            list.Add(new A(6));
            list.Add(new A(7));
            list.Remove(7);
            list.Remove(6);
            list.Remove(5);
            Assert.AreEqual(list.Length, 5);
            Assert.AreEqual(list.Count, 5);
            list.Remove(7);
            list.Remove(4);
            list.Remove(3);
            list.Remove(2);
            list.Remove(1);
            list.Remove(0);
            Assert.AreEqual(list.Length, 0);
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void AddRemoveTest()
        {
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(2));
            list.Remove(1);
            list.Remove(2);
            list.Remove(0);
            list.Add(new A(2));
            list.Add(new A(1));
            list.Add(new A(0));
            list.Remove(0);
            list.Remove(1);
            list.Remove(2);
            Assert.AreEqual(list.Check(0), false);
            Assert.AreEqual(list.Check(1), false);
            Assert.AreEqual(list.Check(2), false);
            Assert.AreEqual(list.Length, 2);
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void CheckTest()
        {
            Init();
            Assert.AreEqual(false, list.Check(-1));
            Assert.AreEqual(false, list.Check(3));
            Assert.AreEqual(true, list.Check(7));
        }


        [TestMethod]
        public void ClearTest()
        {
            Init();
            list.Clear();
            Assert.AreEqual(0, list.Add(new A(4)));
        }


        [TestMethod]
        public void GetAllDatasTest()
        {
            list.Add(new A(0));
            list.Add(new A(1));
            list.Add(new A(2));
            list.Add(new A(3));
            list.Add(new A(4));
            list.Add(new A(5));
            list.Add(new A(6));
            list.Add(new A(7));
            A[] res = list.GetAllDatas();
            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(res[i].A1, list[i].A1);
            }
            list.Clear();
            Init();
            res = list.GetAllDatas();
            int[] als = new int[]
            {
                1,2,4,5,7
            };
            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(res[i].A1, als[i]);
            }
        }

        [TestMethod]
        public void FindDataTest()
        {
            Init();
            A[] res = list.FindData(Seek);
            int[] als = new int[]
            {
               2,4
            };
            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(res[i].A1, als[i]);
            }
        }

        bool Seek(A a)
        {
            if (a.A1 % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        class A
        {
            int a;

            public A(int a)
            {
                this.a = a;
            }

            public int A1 { get => a; set => a = value; }
        }
    }

}
