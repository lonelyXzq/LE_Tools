using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_ToolsTests.StructDataTests
{
    [TestClass]
    public class DataIndexTests
    {
        DataIndex blockInfo;
        public int Size = 8;

        public void AddAll()
        {
            for (int i = 0; i < Size; i++)
            {
                blockInfo.AddData();
            }
        }

        [TestInitialize]
        public void Init()
        {
            blockInfo = new DataIndex(Size);

        }

        [TestMethod]
        public void AddTests()
        {
            AddAll();
            Assert.AreEqual(-1, blockInfo.AddData());
        }

        [TestMethod]
        public void RemoveTests()
        {
            AddAll();
            Assert.AreEqual(true, blockInfo.IsFull);

            blockInfo.RemoveData(5);
            blockInfo.RemoveData(4);
            blockInfo.RemoveData(6);
            Assert.AreEqual(false, blockInfo.Check(5));
            Assert.AreEqual(false, blockInfo.Check(4));
            Assert.AreEqual(false, blockInfo.Check(6));

            Assert.AreEqual(5, blockInfo.AddData());
            Assert.AreEqual(4, blockInfo.AddData());
            Assert.AreEqual(6, blockInfo.AddData());

            for (int i = 0; i < Size; i++)
            {
                blockInfo.RemoveData(i);
            }
            Assert.AreEqual(true, blockInfo.IsEmpty);
            for (int i = 0; i < Size; i++)
            {
                Assert.AreEqual(i, blockInfo.AddData());
            }
            Assert.AreEqual(true, blockInfo.IsFull);
        }

        [TestMethod]
        public void RandRemoveTest()
        {
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.AddData();
            blockInfo.RemoveData(2);
            blockInfo.RemoveData(3);
            blockInfo.RemoveData(1);
            blockInfo.RemoveData(0);
            AddAll();
            blockInfo.RemoveData(5);
            blockInfo.RemoveData(4);
            blockInfo.RemoveData(6);
            blockInfo.RemoveData(3);
            blockInfo.RemoveData(1);
            blockInfo.RemoveData(2);
            blockInfo.RemoveData(0);
            blockInfo.RemoveData(7);
            if (Size == 8)
            {
                Assert.AreEqual(true, blockInfo.IsEmpty);
            }
            Assert.AreEqual(5, blockInfo.AddData());
            Assert.AreEqual(4, blockInfo.AddData());
            Assert.AreEqual(6, blockInfo.AddData());
            Assert.AreEqual(3, blockInfo.AddData());
            Assert.AreEqual(1, blockInfo.AddData());
            Assert.AreEqual(2, blockInfo.AddData());
            Assert.AreEqual(0, blockInfo.AddData());
            Assert.AreEqual(7, blockInfo.AddData());
            Assert.AreEqual(-1, blockInfo.AddData());

            Assert.AreEqual(true, blockInfo.IsFull);
        }
    }
}
