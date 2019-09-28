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
            Fsm<O>.Init();
        }

    }
    class O : IFsmOwner
    {

    }

    [FsmRegister]
    public class FsmT:IFsmProvide
    {
        [FsmActionInfo("a", FsmActiveChance.OnInit,typeof(O))]
        public static void A<O>(O n)
        {

        }

        [FsmActionInfo("b", FsmActiveChance.OnInit, typeof(O))]
        public static void B<O>(O n)
        {

        }
        [FsmActionInfo("b", "a", typeof(O))]
        public static void Bo<O>(O n)
        {

        }
    }

}
