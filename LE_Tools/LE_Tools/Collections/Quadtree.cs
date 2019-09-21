using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    public class Quadtree<T> where T : IQuadData
    {
        public class Node
        {
            private T data;
            private readonly Vector2Int position;
            private readonly int distance;

            public Node(T data, Vector2Int position, int distance)
            {
                this.data = data;
                this.position = position;
                this.distance = distance;
            }

            public T Data { get => data; set => data = value; }

            public Vector2Int Position => position;

            public int Distance => distance;
        }

        private Node[] nodes;

        private Vector2Int center;

        private int radius;

        private int pow;

        private int area;


        public int Radius => radius;

        public int Area => area;

        public Vector2Int Center { get => center; set => center = value; }

        public Node this[int index]
        {
            get
            {
                return nodes[index];
            }
        }

        public Quadtree(int radius, Vector2Int position)
        {
            center = position;
            pow = GetPow(radius);
            Init();
        }

        private int GetPow(int radius)
        {
            int p = 0;
            int mark = ((radius & (radius - 1)) == 0) ? 1 : 0;
            while (radius > mark)
            {
                radius >>= 1;
                p++;
            }
            return p;
        }

        private void Init()
        {
            radius = 1 << pow;
            area = radius * radius * 4;
            nodes = new Node[area];
            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {
                    Vector2Int p = new Vector2Int(i, j);
                    int t1 = GetIndex(p);
                    nodes[t1] = new Node(default, p, p.Magnitude);
                }
            }
        }

        public bool Add(T data)
        {
            int local = GetIndex(data.Position);
            if (local >= area)
            {
                return false;
            }
            nodes[local].Data = data;
            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < area; i++)
            {
                nodes[i].Data = default;
            }
        }

        public T GetData(Vector2Int positon)
        {
            int index = GetIndex(positon);
            if (index >= area)
            {
                return default;
            }
            return nodes[index].Data;
        }

        public void SetRadius(int radius)
        {
            int p = GetPow(radius);
            if (p == pow)
            {
                return;
            }
            pow = p;
            Init();
        }

        public int GetIndex(Vector2Int position)
        {
            int re = 0;
            Vector2Int p = position - center;
            int fre = 0;
            if (p.X < 0)
            {
                p.X = -p.X;
                p.X--;
            }
            else
            {
                fre++;
            }
            if (p.Y < 0)
            {
                p.Y = -p.Y;
                p.Y--;
            }
            else
            {
                fre += 2;
            }
            int mark = 1 << (pow - 1);
            for (int i = 1; i <= pow; i++)
            {
                re <<= 1;
                re += (p.Y & mark) >> (pow - i);
                re <<= 1;
                re += (p.X & mark) >> (pow - i);
                mark >>= 1;
            }
            re <<= 2;
            return re + fre;
        }

    }
}
