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
            //FsmManager<O>.Init();
        }

    }
    class O : IFsmOwner
    {

    }

    [FsmRegister]
    public static class FsmT
    {
        [FsmActionInfo("a", FsmActiveChance.OnInit)]
        public static void A<O>(O n)
        {

        }

        [FsmActionInfo("b", FsmActiveChance.OnInit)]
        public static void B<O>(O n)
        {

        }
        [FsmActionInfo("b", FsmActiveChance.OnInit)]
        public static void Bo<O>(O n)
        {

        }
    }

    [FsmRegister]
    public class FsmT1
    {
        [FsmActionInfo("a", FsmActiveChance.OnUpdate)]
        public void A<O>(O n)
        {

        }

        [FsmActionInfo("b", FsmActiveChance.OnUpdate)]
        public void B<O>(O n)
        {

        }
        [FsmActionInfo("b", FsmActiveChance.OnUpdate)]
        public void Bo<O>(O n)
        {

        }
    }
}
