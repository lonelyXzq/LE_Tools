using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ToolsTests.PerformanceTests
{
    [TestClass]
    public class ForceChange
    {
        [TestMethod]
        public void ForceTests()
        {

            GroupM<A>.Init();
            GroupM<B>.Init();
            GroupM<C>.Init();
            Manger.Init();
            Manger.Create<A>(0);
            Manger.Create<B>(1);
            Manger.Create<C>(2);
            DateTime d1 = DateTime.Now;
            //Group<C> t;
            Group<A> ta;
            for (int i = 0; i < 10000000; i++)
            {
                //t = GroupM<C>.group;//18
                //t = Manger.GetGroup<C>(2);//48
                ta = GroupM<A>.group;//18
                //ta = Manger.GetGroup<A>(0);//70
            }
            DateTime d2 = DateTime.Now;
            Console.WriteLine((d2 - d1).TotalMilliseconds);
        }

        interface IGroup
        {

        }
        class Group<T> : IGroup
        {
            public T[] datas;

            public Group()
            {
                this.datas = new T[20];
            }
        }

        class A
        {

        }

        class B
        {

        }

        struct C
        {
            int a;

            public C(int a)
            {
                this.a = a;
            }
        }

        static class GroupM<T>
        {
            public static Group<T> group;

            public static void Init()
            {
                group = new Group<T>();
            }
        }

        static class Manger
        {
            public static IGroup[] groups;

            public static void Init()
            {
                groups = new IGroup[3];
            }

            public static void Create<T>(int id)
            {
                groups[id] = new Group<T>();
            }

            public static Group<T> GetGroup<T>(int id)
            {
                return (Group<T>)groups[id];
            }
        }
    }
}
