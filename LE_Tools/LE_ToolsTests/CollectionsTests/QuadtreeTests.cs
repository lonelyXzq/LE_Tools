using LE_Tools;
using LE_Tools.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_ToolsTests.CollectionsTests
{
    [TestClass]
    public class QuadtreeTests
    {
        //private Quadtree<Q> quadtree = new Quadtree<Q>(8, Vector2Int.Zero);

        [TestMethod]
        public void QuadtreeTest()
        {
            Quadtree<Q> quadtree = new Quadtree<Q>(7, Vector2Int.Zero);
            Assert.AreEqual(8, quadtree.Radius);
        }

        [TestMethod]
        public void MoveTest()
        {
            Quadtree<Q> quadtree = new Quadtree<Q>(2, Vector2Int.Zero);
            Q q = new Q(0, 0);
            quadtree.Add(q);
            quadtree.Center = new Vector2Int(1, 1);
            Assert.AreEqual(new Vector2Int(0, 0), quadtree.GetData(new Vector2Int(1, 1)).Position);
            quadtree.Clear();
            quadtree.Add(q);
            Assert.AreEqual(new Vector2Int(0, 0), quadtree.GetData(new Vector2Int(0, 0)).Position);
        }

        [TestMethod]
        public void SetRadiusTest()
        {
            Quadtree<Q> quadtree = new Quadtree<Q>(7, Vector2Int.Zero);
            Assert.AreEqual(8, quadtree.Radius);
            quadtree.SetRadius(9);
            Assert.AreEqual(16, quadtree.Radius);
            quadtree.SetRadius(3);
            Assert.AreEqual(4, quadtree.Radius);
        }

        [TestMethod]
        public void AddTest()
        {
            Quadtree<Q> quadtree = new Quadtree<Q>(2, Vector2Int.Zero);
            Q[] qs = new Q[]
            {
                new Q(0,0),
                new Q(1,0),
                new Q(0,1),
                new Q(1,1)
            };
            quadtree.Add(qs[0]);
            quadtree.Add(qs[1]);
            quadtree.Add(qs[2]);
            quadtree.Add(qs[3]);
            int j = 0;
            for (int i = 0; i < quadtree.Area; i++)
            {
                if (quadtree[i].Data != null)
                {
                    Assert.AreEqual(quadtree[i].Data.Position, qs[j].Position);
                    j++;
                }
            }
        }

        [TestMethod]
        public void GetIndexTest()
        {
            Quadtree<Q> quadtree = new Quadtree<Q>(8, Vector2Int.Zero);
            Assert.AreEqual((41 << 2), quadtree.GetIndex(new Vector2Int(-2, -7)));
            Assert.AreEqual((41 << 2) + 2, quadtree.GetIndex(new Vector2Int(-2, 6)));
            Assert.AreEqual((41 << 2) + 1, quadtree.GetIndex(new Vector2Int(1, -7)));
            Assert.AreEqual((41 << 2) + 3, quadtree.GetIndex(new Vector2Int(1, 6)));
            Assert.AreEqual((41 << 2) + 3, quadtree.GetIndex(new Vector2Int(9, 6)));
            Assert.AreEqual((41 << 2) + 3, quadtree.GetIndex(new Vector2Int(1, 14)));
        }
    }

    class Q : IQuadData
    {
        private readonly Vector2Int position;

        public Q(int x,int y)
        {
            this.position = new Vector2Int(x,y);
        }

        public Vector2Int Position => position;

        public bool Equals(IQuadData quadData)
        {
            return position == quadData.Position;
        }
    }
}