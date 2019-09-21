using LE_Tools;
using LE_Tools.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_ToolsTests.CollectionsTests
{
    [TestClass]
    public class StructListTests
    {
        private LE_StructList<DataA> list;

        [TestInitialize]
        public void Init()
        {
            list = new LE_StructList<DataA>();
            list.Add(new DataA(0));
            list.Add(new DataA(1));
            list.Add(new DataA(2));
            list.Add(new DataA(3));
            list.Add(new DataA(4));
        }

        [TestMethod]
        public void AddTest()
        {
            int[] re = new int[6];
            re[0] = list.Add(new DataA(1));
            re[1] = list.Add(new DataA(2));
            re[2] = list.Add(new DataA(3));
            re[3] = list.Add(new DataA(4));
            re[4] = list.Add(new DataA(5));
            re[5] = list.Add(new DataA(6));
            Assert.AreEqual(list.Count,list.Length, 11);
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(re[i], i + 5);
                Assert.AreEqual(list[i + 5], new DataA(i + 1));
            }
        }

        [TestMethod]
        public void CheckTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(list.Check(i), true);
            }
            list.Remove(4);
            Assert.AreEqual(list.Check(4), false);
            list.Add(new DataA(4));
            Assert.AreEqual(list.Check(4), true);
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Add(new DataA(5));
            list.Add(new DataA(6));
            list.Add(new DataA(7));
            list.Add(new DataA(8));
            list.Add(new DataA(9));
            list.Remove(6);
            list.Remove(8);
            list.Remove(9);
            Assert.AreEqual(list.Length - list.Count, 3);
            Assert.AreEqual(list.Check(5), true);
            Assert.AreEqual(list.Check(6), false);
            Assert.AreEqual(list.Check(7), true);
            Assert.AreEqual(list.Check(8), false);
            Assert.AreEqual(list.Check(9), false);
            int a = list.Add(new DataA(1));
            Assert.AreEqual(a, 6);
            a = list.Add(new DataA(2));
            Assert.AreEqual(a, 8);
            a = list.Add(new DataA(3));
            Assert.AreEqual(a, 9);
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Clear();
            Assert.AreEqual(list.Count, list.Length, 0);
        }
    }

    struct DataA
    {
        public int a;

        public DataA(int a)
        {
            this.a = a;
        }

        public override string ToString()
        {
            return a.ToString();
        }
    }
}
