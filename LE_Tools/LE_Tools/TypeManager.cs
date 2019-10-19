using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;

namespace LE_Tools
{
    public static class TypeManager
    {
        private static string path = ".\\";
        private static IReadOnlyList<Assembly> assemblies;
        private static IReadOnlyList<Type> types;

        private static volatile int mark = 0;

        public static int count = 16;

        public static string AssembliesPath
        {
            get
            {
                return path;
            }
        }

        static TypeManager()
        {
            if (Interlocked.CompareExchange(ref mark, 1, 0) == 0)
            {
                CreateAssemblies();
            }
        }

        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static T CreateInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public static T CreateInstance<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        private static void CreateAssemblies()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var fs = directoryInfo.GetFiles();
            var ass = new List<Assembly>();
            for (int i = 0; i < fs.Length; i++)
            {
                if (fs[i].Extension == ".dll")
                {
                    //
                    var name = fs[i].Name.AsSpan();
                    string t = name.Slice(0, name.Length - 4).ToString();
                    if (!t.Contains('.'))
                    {
                        ass.Add(Assembly.Load(t));
                        Console.WriteLine(fs[i].Name);
                    }

                }
            }
            List<Type> tp = new List<Type>();
            for (int i = 0; i < ass.Count; i++)
            {
                try
                {
                    var ts = ass[i].GetTypes();
                    tp.AddRange(ts);
                }
                catch (Exception e)
                {
                    LE_Log.Log.FatalError("Load assembly error", "assembly load fail:{0}\r\n    {1}", ass[i].FullName, e.Message);
                }
            }
            assemblies = ass;
            types = tp;
        }

        public static Type[] GetTypes(Func<Type, bool> func)
        {

            ConcurrentBag<Type> ts = new ConcurrentBag<Type>();
            Parallel.For(0, assemblies.Count, (i) =>
            {
                GetTypes(assemblies[i], ts, func);
            }
            );
            //int size = types.Count / count;
            //Parallel.For(0, count, (i) =>
            //{
            //    Get(i * size, (i + 1) * size, ts, func);
            //}
            //);
            return ts.ToArray();
            //return AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(a => a.GetTypes().Where(func))
            //    .ToArray();
        }

        private static void Get(int st, int en, ConcurrentBag<Type> t, Func<Type, bool> func)
        {
            if (en >= types.Count)
            {
                en = types.Count;
            }
            for (int i = st; i < en; i++)
            {
                if (func?.Invoke(types[i]) ?? false)
                {
                    t.Add(types[i]);
                }
            }
        }

        private static void GetTypes(Assembly assembly, ConcurrentBag<Type> types, Func<Type, bool> func)
        {
            try
            {
                var ts = assembly.GetTypes();
                //Console.WriteLine(ts.Length);
                for (int i = 0; i < ts.Length; i++)
                {
                    if (func?.Invoke(ts[i]) ?? false)
                    {
                        types.Add(ts[i]);
                    }
                }
            }
            catch (Exception e)
            {

                LE_Log.Log.FatalError("Load assembly error", "assembly load fail:{0}\r\n    {1}", assembly.FullName, e.Message);
            }
        }
    }
}
