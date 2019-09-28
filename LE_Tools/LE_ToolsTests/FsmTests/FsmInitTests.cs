using LE_Tools.Fsm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.FsmTests
{
    [TestClass]
    public class FsmInitTests
    {
        [TestMethod]
        public void InitTest()
        {
            FsmManager.Init();
            O o = new O();
            //Fsm<O>.ChangeState(o, "a", "b");
        }

        [TestMethod]
        public void OwnerTest()
        {
            FsmManager.Init();
            O o = new O();
            o.helper.OnInit();
            o.helper.OnUpdate();
            o.helper.Change("b");
            o.helper.OnUpdate();
            o.helper.Change("c");
            o.helper.OnUpdate();
            o.helper.Change("a");
            o.helper.OnUpdate();
            o.helper.Change("c");
            o.helper.OnUpdate();
            o.helper.Change("b");
            o.helper.OnUpdate();
            o.helper.Change("a");
            o.helper.OnUpdate();
            o.helper.Ondestory();
        }

        [TestMethod]
        public void InstanceTest()
        {
            FsmManager.Init();
            O o = new O();
            o.helper.OnInit();
            o.helper.InstanceFsm.AddAction("a", "b", A);
            o.helper.OnUpdate();
            o.helper.Change("b");
            o.helper.OnUpdate();
            o.helper.Change("c");
            o.helper.Ondestory();
            Console.WriteLine("------------------");
            O o1 = new O();
            o1.helper.OnInit();
            o1.helper.OnUpdate();
            o1.helper.Change("b");
            o1.helper.OnUpdate();
            o1.helper.Change("c");
            o1.helper.Ondestory();
        }

        [TestMethod]
        public void AddStateTests()
        {
            FsmManager.Init();
            O o = new O();
            o.helper.InstanceFsm.AddState("d");
            o.helper.InstanceFsm.AddAction("a", "d", B);
            o.helper.InstanceFsm.AddAction("d", "a", B1);
            o.helper.OnInit();
            o.helper.OnUpdate();
            Console.WriteLine("_____");
            o.helper.Change("d");
            Console.WriteLine("_____");
            o.helper.Change("a");
            Console.WriteLine("_____");
            o.helper.Change("b");
            o.helper.OnUpdate();
            o.helper.Change("c");
            Console.WriteLine("------------------");
            O o1 = new O();
            o1.helper.OnInit();
            o1.helper.OnUpdate();
            o1.helper.Change("b");
            o1.helper.OnUpdate();
            o1.helper.Change("c");
        }

        public static void B<O>(O n)
        {
            Console.WriteLine("change AD instance");
        }
        public static void B1<O>(O n)
        {
            Console.WriteLine("change DA instance");
        }

        public static void A<O>(O n)
        {
            Console.WriteLine("change AB instance");
        }
    }
    class O : IFsmOwner
    {
        public FsmHelper<O> helper;
        public O()
        {
            helper = new FsmHelper<O>("a", this);
        }
    }

    public class FsmT : IFsmProvider
    {
        public static void A0<O>(O n)
        {
            Console.WriteLine("init A");
        }

        public static void A1<O>(O n)
        {
            Console.WriteLine("enter A");
        }

        public static void A2<O>(O n)
        {
            Console.WriteLine("update A");
        }

        public static void A3<O>(O n)
        {
            Console.WriteLine("leave A");
        }
        public static void A4<O>(O n)
        {
            Console.WriteLine("destory A");
        }

        public static void B0<O>(O n)
        {
            Console.WriteLine("init B");
        }

        public static void B1<O>(O n)
        {
            Console.WriteLine("enter B");
        }

        public static void B2<O>(O n)
        {
            Console.WriteLine("update B");
        }

        public static void B3<O>(O n)
        {
            Console.WriteLine("leave B");
        }
        public static void B4<O>(O n)
        {
            Console.WriteLine("destory B");
        }

        public static void C0<O>(O n)
        {
            Console.WriteLine("init C");
        }

        public static void C1<O>(O n)
        {
            Console.WriteLine("enter C");
        }

        public static void C2<O>(O n)
        {
            Console.WriteLine("update C");
        }

        public static void C3<O>(O n)
        {
            Console.WriteLine("leave C");
        }
        public static void C4<O>(O n)
        {
            Console.WriteLine("destory C");
        }

        public static void AB<O>(O n)
        {
            Console.WriteLine("change AB");
        }

        public static void BA<O>(O n)
        {
            Console.WriteLine("change BA");
        }

        public static void BC<O>(O n)
        {
            Console.WriteLine("change BC");
        }

        public static void CB<O>(O n)
        {
            Console.WriteLine("change CB");
        }

        public static void CA<O>(O n)
        {
            Console.WriteLine("change CA");
        }

        public static void AC<O>(O n)
        {
            Console.WriteLine("change AC");
        }

        public void Init()
        {
            FsmBuilder<O>.Builder.BuildState("a", "b", "c");
            FsmBuilder<O>.Builder.AddAction("a", FsmActiveChance.OnInit, A0);
            FsmBuilder<O>.Builder.AddAction("a", FsmActiveChance.OnEnter, A1);
            FsmBuilder<O>.Builder.AddAction("a", FsmActiveChance.OnUpdate, A2);
            FsmBuilder<O>.Builder.AddAction("a", FsmActiveChance.OnLeave, A3);
            FsmBuilder<O>.Builder.AddAction("a", FsmActiveChance.OnDestory, A4);

            FsmBuilder<O>.Builder.AddAction("b", FsmActiveChance.OnInit, B0);
            FsmBuilder<O>.Builder.AddAction("b", FsmActiveChance.OnEnter, B1);
            FsmBuilder<O>.Builder.AddAction("b", FsmActiveChance.OnUpdate, B2);
            FsmBuilder<O>.Builder.AddAction("b", FsmActiveChance.OnLeave, B3);
            FsmBuilder<O>.Builder.AddAction("b", FsmActiveChance.OnDestory, B4);

            FsmBuilder<O>.Builder.AddAction("c", FsmActiveChance.OnInit, C0);
            FsmBuilder<O>.Builder.AddAction("c", FsmActiveChance.OnEnter, C1);
            FsmBuilder<O>.Builder.AddAction("c", FsmActiveChance.OnUpdate, C2);
            FsmBuilder<O>.Builder.AddAction("c", FsmActiveChance.OnLeave, C3);
            FsmBuilder<O>.Builder.AddAction("c", FsmActiveChance.OnDestory, C4);

            FsmBuilder<O>.Builder.AddAction("a", "b", AB);
            FsmBuilder<O>.Builder.AddAction("b", "c", BC);
            FsmBuilder<O>.Builder.AddAction("c", "a", CA);
            FsmBuilder<O>.Builder.AddAction("b", "a", BA);
            FsmBuilder<O>.Builder.AddAction("c", "b", CB);
            FsmBuilder<O>.Builder.AddAction("a", "c", AC);
        }
    }

}
