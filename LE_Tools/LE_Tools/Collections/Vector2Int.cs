using System;

namespace LE_Tools.Collections
{
    public struct Vector2Int
    {
        public static Vector2Int Zero = new Vector2Int(0, 0);
        private int x;
        private int y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public int Magnitude => (int)Math.Sqrt(x * x + y * y);

        public static bool operator ==(Vector2Int v1, Vector2Int v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector2Int v1, Vector2Int v2)
        {
            return !(v1.x == v2.x && v1.y == v2.y);
        }

        public static Vector2Int operator +(Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2Int operator -(Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2Int operator *(Vector2Int v1, int v2)
        {
            return new Vector2Int(v1.x * v2, v1.y * v2);
        }

        public static Vector2Int operator /(Vector2Int v1, int v2)
        {
            return new Vector2Int(v1.x / v2, v1.y / v2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}
