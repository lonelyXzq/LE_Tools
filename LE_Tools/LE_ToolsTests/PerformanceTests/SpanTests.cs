using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class SpanTests
    {
        [TestMethod]
        public void BuildTest()
        {
            unsafe
            {
                Console.WriteLine(sizeof(A));
                Console.WriteLine(sizeof(A*));
                Console.WriteLine(sizeof(int));
                Console.WriteLine(sizeof(B));
            }
        }

        [TestMethod]
        public void UnsafeTest()
        {
            unsafe
            {
                A t = new A(5);
                A* a = &t;
                a->a = 3;
                Console.WriteLine(t.a);
            }
            DateTime date1 = DateTime.Now;
            A0 a01 = new B0();
            B0 b01;
            for (int i = 0; i < 1000000; i++)
            {
                b01 = (B0)a01;
            }
            DateTime d11 = DateTime.Now;
            Console.WriteLine((d11 - date1).TotalMilliseconds);
            var _ = BenchmarkRunner.Run<TA>();
        }

        public class TA
        {
            [Benchmark]
            public void Channge()
            {

                unsafe
                {
                    A a = new A(1);
                    A* t = &a;
                    void* x = t;
                    A* t0;
                    for (int i = 0; i < 1000; i++)
                    {
                        t0 = (A*)x;
                    }
                }
            }

            [Benchmark]
            public void StaticProperty()
            {
                int id;
                for (int i = 0; i < 1000; i++)
                {
                    id=SD<int>.id;
                }
            }

            [Benchmark]
            public void SafeChange()
            {
                A0 a = new B0();
                B0 b;
                for (int i = 0; i < 1000; i++)
                {
                    b = (B0)a;
                }
            }

            [Benchmark]
            public void BeforeChannge()
            {
                unsafe
                {
                    A a = new A(1);
                    A* t = &a;
                    void* x = t;
                    A* t0;
                }
            }

            [Benchmark]
            public void Add()
            {
                unsafe
                {
                    long x = 1;
                    long y = 1;
                    for (int i = 0; i < 1000; i++)
                    {
                        x += y;
                    }
                }
            }



            [Benchmark]
            public void AddInt()
            {
                unsafe
                {
                    int x = 1;
                    int y = 1;
                    for (int i = 0; i < 1000; i++)
                    {
                        x += y;
                    }
                }
            }
        }

        static class SD<T>
        {
            public static int id=5;
        }


        class A0
        {

        }

        class B0 : A0
        {

        }

        struct At<T>
        {

        }

        unsafe struct B
        {
            //public A* n;
            //public A* n1;
            //public A* n2;
            public long x;
            public int x0;
        }

        unsafe struct A
        {
            public int a;
            //public fixed int t[10];
            public A* n;
            public A* n1;
            public A* n2;
            public A(int a)
            {
                this.a = a;
                n = (A*)0;
                n1 = (A*)0;
                n2 = (A*)0;
            }
        }
    }
}
