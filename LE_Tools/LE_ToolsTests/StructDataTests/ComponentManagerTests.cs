using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static LE_ToolsTests.StructDataTests.InitTests;

namespace LE_ToolsTests.StructDataTests
{
    [TestClass]
    public class ComponentManagerTests
    {
        ComponentManager componentManager;

        [TestInitialize]
        public void Init()
        {
            DataManager.Register(new Type[] { typeof(A), typeof(B), typeof(C) });
            EntityTypeManager.Register(new Type[] { typeof(TypeA), typeof(TypeB) });
            componentManager = new ComponentManager();
        }

        [TestMethod]
        public void AddTest()
        {
            for (int i = 0; i <Component.BlockSize; i++)
            {
                Assert.AreEqual(i, componentManager.AddEntity(0));
                Assert.AreEqual(i+ Component.BlockSize, componentManager.AddEntity(1));
            }

            for (int i = 0; i < Component.BlockSize; i++)
            {
                Assert.AreEqual(i+Component.BlockSize*2, componentManager.AddEntity(0));
                Assert.AreEqual(i + Component.BlockSize*3, componentManager.AddEntity(1));
            }
        }
    }
}
