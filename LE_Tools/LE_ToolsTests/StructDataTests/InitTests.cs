using LE_Tools.Collections;
using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.StructDataTests
{
    [TestClass]
    public class InitTests
    {
        [TestMethod]
        public void DataInitTest()
        {
            DataManager.Init();
            //Assert.AreEqual(2, DataManager.Count);
            //Assert.AreEqual(0,DataInfo<A>.Id);
            //Assert.AreEqual(1, DataInfo<B>.Id);

            Assert.AreEqual(typeof(SteadyList<BlockNode<A>>), DataManager.DataBlockManagers[DataInfo<A>.Id].GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode<B>>), DataManager.DataBlockManagers[DataInfo<B>.Id].GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode<A>>), DataInfo<A>.DataBlocks.GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode<B>>), DataInfo<B>.DataBlocks.GetType());
        }

        [TestMethod]
        public void TypeInitTests()
        {
            DataManager.Init();
            EntityTypeManager.Init();
            //Assert.AreEqual(2, EntityTypeManager.Count);
            int id = LE_Tools.IdManager.IdDeliverer.GetId<TypeA>();
            var t = EntityTypeManager.Type_Es[id];
            Assert.AreEqual(typeof(TypeA).FullName, t.Name);
            Assert.AreEqual(id, t.Id);
            Assert.AreEqual(true, t.Info.Get(DataInfo<A>.Id));
            Assert.AreEqual(true, t.Info.Get(DataInfo<B>.Id));
            Assert.AreEqual(typeof(TypeA), t.EntityType.GetType());
            id = LE_Tools.IdManager.IdDeliverer.GetId<TypeB>();
            t = EntityTypeManager.Type_Es[id];
            Assert.AreEqual(typeof(TypeB).FullName, t.Name);
            Assert.AreEqual(id, t.Id);
            Assert.AreEqual(false, t.Info.Get(DataInfo<A>.Id));
            Assert.AreEqual(true, t.Info.Get(DataInfo<B>.Id));
            Assert.AreEqual(typeof(TypeB), t.EntityType.GetType());
        }

        public class TypeA : IEntityType
        {
            public A a;
            public B b;

            public void Init(Entity_S entity)
            {

            }
        }

        public class TypeB : IEntityType
        {
            public B b;

            public void Init(Entity_S entity)
            {

            }
        }

        public struct A : IData
        {
            int a;
        }

        public struct B : IData
        {
            int b;
        }


    }
}
