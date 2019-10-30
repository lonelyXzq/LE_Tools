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
        [TestInitialize]
        public void Init()
        {
            DataManager.Register(new Type[] { typeof(A), typeof(B), typeof(C) });
            EntityTypeManager.Register(new Type[] { typeof(TypeA), typeof(TypeB) });
        }

        [TestMethod]
        public void DataInitTest()
        {
            //DataManager.Init();
            Assert.AreEqual(3, DataManager.Count);
            Assert.AreEqual(0,DataInfo<A>.Id);
            Assert.AreEqual(1, DataInfo<B>.Id);
            Assert.AreEqual(2, DataInfo<C>.Id);
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataManager.DataBlockManagers[DataInfo<A>.Id].GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataManager.DataBlockManagers[DataInfo<B>.Id].GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataManager.DataBlockManagers[DataInfo<C>.Id].GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataInfo<A>.DataBlocks.GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataInfo<B>.DataBlocks.GetType());
            Assert.AreEqual(typeof(SteadyList<BlockNode>), DataInfo<C>.DataBlocks.GetType());
        }

        [TestMethod]
        public void TypeInitTests()
        {
            //DataManager.Init();
            //EntityTypeManager.Init();
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
            public int a;

            public A(int a)
            {
                this.a = a;
            }
        }

        public struct B : IData
        {
            public int b;

            public B(int b)
            {
                this.b = b;
            }
        }

        public struct C : IData
        {
            public int c;

            public C(int c)
            {
                this.c = c;
            }
        }
    }
}
