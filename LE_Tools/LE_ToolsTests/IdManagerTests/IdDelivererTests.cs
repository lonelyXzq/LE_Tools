using LE_Tools.IdManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.IdManagerTests
{
    [TestClass]
    public class IdDelivererTests
    {
        [TestMethod]
        public void IdTest()
        {
            Console.WriteLine(IdDeliverer.CreateId<IB, A>());
            Console.WriteLine(IdDeliverer.CreateId<IB, B>());
            Console.WriteLine(IdDeliverer.CreateId<IB, C>());
            Console.WriteLine(IdDeliverer.CreateId<IC, A0>());
            Console.WriteLine(IdDeliverer.CreateId<IC, B0>());
            Console.WriteLine(IdDeliverer.CreateId<IC, C0>());

            Console.WriteLine(IdDeliverer.GetLongId<IB, A>());
            Console.WriteLine(IdDeliverer.GetLongId<IB, B>());
            Console.WriteLine(IdDeliverer.GetLongId<IB, C>());
            Console.WriteLine(IdDeliverer.GetLongId<IC, A0>());
            Console.WriteLine(IdDeliverer.GetLongId<IC, B0>());
            Console.WriteLine(IdDeliverer.GetLongId<IC, C0>());

            Assert.AreEqual(IdDeliverer.GetId<A>(), 0);
            Assert.AreEqual(IdDeliverer.GetId<B>(), 1);
            Assert.AreEqual(IdDeliverer.GetId<C>(), 2);
            Assert.AreEqual(IdDeliverer.GetId<A0>(), 0);
            Assert.AreEqual(IdDeliverer.GetId<B0>(), 1);
            Assert.AreEqual(IdDeliverer.GetId<C0>(), 2);

            Assert.AreEqual(IdDeliverer.GetCount<IB>(), 3);
            Assert.AreEqual(IdDeliverer.GetCount<IC>(), 3);

            Assert.AreEqual(IdDeliverer.GetBaseId<IB>(), 0);
            Assert.AreEqual(IdDeliverer.GetBaseId<IC>(), 1);

            Assert.AreEqual(IdDeliverer.GetLongId<IB, A>(), 0x0000000000000000);
            Assert.AreEqual(IdDeliverer.GetLongId<IB, B>(), 0x0000000000000001);
            Assert.AreEqual(IdDeliverer.GetLongId<IB, C>(), 0x0000000000000002);
            Assert.AreEqual(IdDeliverer.GetLongId<IC, A0>(), 0x0000000100000000);
            Assert.AreEqual(IdDeliverer.GetLongId<IC, B0>(), 0x0000000100000001);
            Assert.AreEqual(IdDeliverer.GetLongId<IC, C0>(), 0x0000000100000002);
        }

        interface IB
        {

        }

        public class A : IB
        {

        }

        public class B : IB
        {

        }

        public class C : IB
        {

        }

        interface IC
        {

        }

        public class A0 : IC
        {

        }

        public class B0 : IC
        {

        }

        public class C0 : IC
        {

        }
    }
}
