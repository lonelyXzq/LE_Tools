using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static LE_ToolsTests.StructDataTests.InitTests;

namespace LE_ToolsTests.StructDataTests
{
    [TestClass]
    public class ComponentTests
    {
        Component component;

        [TestInitialize]
        public void Init()
        {
            DataManager.Register(new Type[] { typeof(A), typeof(B), typeof(C) });
            EntityTypeManager.Register(new Type[] { typeof(TypeA), typeof(TypeB) });
            component = new Component(EntityTypeManager.Type_Es[0], 0);
        }

        [TestMethod]
        public void BaseTest()
        {

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(component.AddComponent(), i);
            }
            component.RemoveComponent(3);
            Assert.AreEqual(component.DataIndex.Check(3), false);
        }


        [TestMethod]
        public void GetSetTest()
        {
            for (int i = 0; i < 5; i++)
            {
                component.AddComponent();
            }
            component.SetData(3, new A(3));
            A a = component.GetData<A>(3);
            Assert.AreEqual(a.a, 3);

            component.SetData(5, new A(5));
            a = component.GetData<A>(5);
            Assert.AreEqual(a.a, 0);

            component.SetData(3, new C(3));
            C c = component.GetData<C>(3);
            Assert.AreEqual(c.c, 0);
        }
    }
}
