using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void AddTest()
        {
            BenchmarkRunner.Run<AddTests>();
        }

        [Benchmark]
        public void ByteAdd()
        {
            byte x = 1;
            byte y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void ByteAdd2()
        {
           
            byte y = 1;
            byte x = 1;
            for (int i = 0; i < 200; i++)
            {
                x += y;
            }
            x = 1;
            for (int i = 0; i < 200; i++)
            {
                x += y;
            }
            x = 1;
            for (int i = 0; i < 200; i++)
            {
                x += y;
            }
            x = 1;
            for (int i = 0; i < 200; i++)
            {
                x += y;
            }
            x = 1;
            for (int i = 0; i < 200; i++)
            {
                x += y;
            }
        }


        [Benchmark]
        public void ShortAdd()
        {
            short x = 1;
            short y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void UShortAdd()
        {
            ushort x = 1;
            ushort y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void IntAdd()
        {
            int x = 1;
            int y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void UIntAdd()
        {
            uint x = 1;
            uint y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void LongAdd()
        {
            long x = 1;
            long y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }

        [Benchmark]
        public void ULongAdd()
        {
            ulong x = 1;
            ulong y = 1;
            for (int i = 0; i < 1000; i++)
            {
                x += y;
            }
        }
    }
}
