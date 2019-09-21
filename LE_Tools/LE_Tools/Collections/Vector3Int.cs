using System;

namespace LE_Tools.Collections
{
    public struct Vector3Int
    {
        public static Vector3Int Zero = new Vector3Int(0, 0, 0);

        private int x;
        private int y;
        private int z;

        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }

        public int Magnitude => (int)Math.Sqrt(x * x + y * y + z * z);

        public static bool operator ==(Vector3Int v1, Vector3Int v2)
        {
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        }

        public static bool operator !=(Vector3Int v1, Vector3Int v2)
        {
            return !(v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static Vector3Int operator +(Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3Int operator -(Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3Int operator *(Vector3Int v1, int v2)
        {
            return new Vector3Int(v1.x * v2, v1.y * v2, v1.z * v2);
        }

        public static Vector3Int operator /(Vector3Int v1, int v2)
        {
            return new Vector3Int(v1.x / v2, v1.y / v2, v1.z / v2);
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
            return string.Format("({0},{1},{2})", x, y, z);
        }
    }
}
