using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LE_Tools.StructData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public unsafe class MarshalTests
    {
        private IntPtr n;

        [TestMethod]
        public void ChangTest()
        {
            int s;
            unsafe
            {
                s = sizeof(A);
            }
            n = Marshal.AllocHGlobal(s);
            //BenchmarkRunner.Run<MarshalTests>();
            DateTime d1 = DateTime.Now;
            UnManagerTest();
            DateTime d2 = DateTime.Now;
            Console.WriteLine((d2 - d1).TotalMilliseconds);
            var a = Get();
            Console.WriteLine(a.a);
            Marshal.FreeHGlobal(n);

        }

        [TestMethod]
        public void SpanTest()
        {
            int s;
            unsafe
            {
                s = sizeof(A);
                n = Marshal.AllocHGlobal(s);
                //DateTime d1 = DateTime.Now;
                //UnManagerWithSpanTest();
                //DateTime d2 = DateTime.Now;
                //Console.WriteLine((d2 - d1).TotalMilliseconds);
                //var a = Get();
                //Console.WriteLine(a.a);
                BenchmarkRunner.Run<MarshalTests>();
                Marshal.FreeHGlobal(n);
            }

        }

        [Benchmark]
        public void UnManagerWithSpanTest()
        {
            unsafe
            {

                //int a = 1;
                //int b = 1;
                for (int i = 0; i < 1000; i++)
                {
                    //a += b;
                    Span<A> span = new Span<A>(n.ToPointer(), 1);
                    //Span<A> span = new Span<A>(ts);
                    span[0].a = i;
                }
            }
        }

        //[Benchmark]
        public void UnManagerTest()
        {
            A a=new A();
            for (int i = 0; i < 1000000; i++)
            {
                //a.a++;
                a = Get();
                a.a = i;
                Set(a);
            }
        }

        void Set(A a)
        {
            Marshal.StructureToPtr(a, n, false);
        }

        A Get()
        {
            return Marshal.PtrToStructure<A>(n);
        }

        unsafe struct A:IData
        {
            public int a;
            public fixed int b[31];
        }

    }
}
