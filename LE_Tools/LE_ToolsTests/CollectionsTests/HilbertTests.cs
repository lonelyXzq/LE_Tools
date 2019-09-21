using LE_Tools.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LE_ToolsTests.CollectionsTests
{
    [TestClass]
    public class HilbertTests
    {
        [TestMethod()]
        [DataRow(7, 7)]
        [DataRow(-7, -7)]
        [DataRow(-1, 0)]
        [DataRow(1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 1)]
        public void GetCodeTest(int x, int y)
        {
            ulong t = Hilbert.GetCode(new Vector2Int(x, y));
            t = (t << 2) >> 2;
            Console.WriteLine(t);
        }

        [TestMethod()]
        [DataRow(0uL, 0)]
        [DataRow(0uL, 1)]
        [DataRow(0uL, 2)]
        [DataRow(0uL, 3)]
        public void GetNearTest(ulong code, int mark)
        {
            ulong t = Hilbert.GetNear(code, mark);
            Console.WriteLine(Hilbert.GetPosition(t));
        }

        [TestMethod()]
        [DataRow(42uL)]
        [DataRow(1uL)]
        [DataRow(3uL)]
        public void GetPositionTest(ulong code)
        {
            Vector2Int re = Hilbert.GetPosition(code);
            Console.WriteLine(re);
        }
    }
}


