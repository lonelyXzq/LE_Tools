using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_Tools.Collections
{
    public static class Hilbert
    {
        static readonly int[,] map = new int[4, 4]
        {
            { 0,1,3,2},
            { 2,1,3,0},
            { 2,3,1,0},
            { 0,3,1,2}
        };

        static readonly int[,] map_un = new int[4, 4]
        {
            { 0,1,3,2},
            { 3,1,0,2},
            { 3,2,0,1},
            { 0,2,3,1}
        };

        static readonly int[,] next = new int[4, 4]
        {
            { 3,0,1,0},
            { 1,1,0,2},
            { 2,3,2,1},
            { 0,2,3,3}
        };

        public static ulong GetCode(Vector2Int position)
        {
            ulong re = 0;
            if (position.X < 0)
            {
                position.X = -position.X;
                re += 0x8000000000000000;
            }
            if (position.Y < 0)
            {
                position.Y = -position.Y;
                re += 0x4000000000000000;
            }
            re += (ulong)Encode(position.X, position.Y);
            return re;
        }

        public static Vector2Int GetPosition(ulong code)
        {
            int t = (int)((code & 0xc000000000000000) >> 62);
            Decode((long)code, out int x, out int y);
            if ((t & 2) > 0)
            {
                x = -x;
            }
            if ((t & 1) > 0)
            {
                y = -y;
            }
            return new Vector2Int(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="mark">
        /// x-1;x+1;y-1;y+1;
        /// </param>
        /// <returns></returns>
        public static ulong GetNear(ulong position, int mark)
        {
            Vector2Int p = GetPosition(position);
            switch (mark)
            {
                case 0:
                    p.X--;
                    break;
                case 1:
                    p.X++;
                    break;
                case 2:
                    p.Y--;
                    break;
                case 3:
                    p.Y++;
                    break;
                default:
                    break;
            }
            return GetCode(p);
        }

        static long Encode(int x, int y)
        {
            int nowState = 0;
            int[] x0 = new int[16];
            int[] y0 = new int[16];
            int k = 0;
            for (int i = 0; i < 16; i++)
            {
                x0[i] = x & 3;
                y0[i] = y & 3;
                x >>= 2;
                y >>= 2;
                if (x0[i] != 0 || y0[i] != 0)
                {
                    k = i;
                }
            }
            int t = 0;
            long re = 0;
            for (int i = k; i > -1; i--)
            {
                re <<= 2;
                t = (x0[i] & 2) + ((y0[i] & 2) >> 1);
                re += map[nowState, t];
                nowState = next[nowState, t];
                re <<= 2;
                t = ((x0[i] & 1) << 1) + (y0[i] & 1);
                re += map[nowState, t];
                nowState = next[nowState, t];
            }
            return re;
        }

        static void Decode(long index, out int x, out int y)
        {
            x = 0;
            y = 0;
            int nowState = 0;
            int re = 0;
            int[] code = new int[16];
            int k = 0;
            for (int i = 0; i < 16; i++)
            {
                code[i] = (int)(index & 15);
                index >>= 4;
                if (code[i] > 0)
                {
                    k = i;
                }
            }
            code[15] &= 3;
            int t = 0;
            for (int i = k; i > -1; i--)
            {
                if (code[i] == 0)
                {
                    x <<= 2;
                    y <<= 2;
                    continue;
                }
                t = (code[i] & 12) >> 2;
                re = map_un[nowState, t];
                nowState = next[nowState, re];
                x <<= 1;
                y <<= 1;
                x += re / 2;
                y += re % 2;
                t = code[i] & 3;
                re = map_un[nowState, t];
                nowState = next[nowState, re];
                x <<= 1;
                y <<= 1;
                x += re / 2;
                y += re % 2;
            }
        }

    }
}
