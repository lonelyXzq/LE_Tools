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
            Fsm<O>.Instance.ChangeState(o, "a", "b");
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
            Fsm<O>.BuildState("a", "b", "c");
            Fsm<O>.Instance.AddAction("a", FsmActiveChance.OnInit, A0);
            Fsm<O>.Instance.AddAction("a", FsmActiveChance.OnEnter, A1);
            Fsm<O>.Instance.AddAction("a", FsmActiveChance.OnUpdate, A2);
            Fsm<O>.Instance.AddAction("a", FsmActiveChance.OnLeave, A3);
            Fsm<O>.Instance.AddAction("a", FsmActiveChance.OnDestory, A4);

            Fsm<O>.Instance.AddAction("b", FsmActiveChance.OnInit, B0);
            Fsm<O>.Instance.AddAction("b", FsmActiveChance.OnEnter, B1);
            Fsm<O>.Instance.AddAction("b", FsmActiveChance.OnUpdate, B2);
            Fsm<O>.Instance.AddAction("b", FsmActiveChance.OnLeave, B3);
            Fsm<O>.Instance.AddAction("b", FsmActiveChance.OnDestory, B4);

            Fsm<O>.Instance.AddAction("c", FsmActiveChance.OnInit, C0);
            Fsm<O>.Instance.AddAction("c", FsmActiveChance.OnEnter, C1);
            Fsm<O>.Instance.AddAction("c", FsmActiveChance.OnUpdate, C2);
            Fsm<O>.Instance.AddAction("c", FsmActiveChance.OnLeave, C3);
            Fsm<O>.Instance.AddAction("c", FsmActiveChance.OnDestory, C4);

            Fsm<O>.Instance.AddAction("a", "b", AB);
            Fsm<O>.Instance.AddAction("b", "c", BC);
            Fsm<O>.Instance.AddAction("c", "a", CA);
            Fsm<O>.Instance.AddAction("b", "a", BA);
            Fsm<O>.Instance.AddAction("c", "b", CB);
            Fsm<O>.Instance.AddAction("a", "c", AC);
        }
    }

}
