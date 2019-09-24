using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LE_Tools
{
    public static class TypeManager
    {
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

        public static Type[] GetTypes(Func<Type, bool> func)
        {
            List<Type> types = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type>[] tts = new List<Type>[assemblies.Length];
            for (int i = 0; i < tts.Length; i++)
            {
                tts[i] = new List<Type>();
            }
            Parallel.For(0, assemblies.Length, (i) =>
            {
                GetTypes(assemblies[i], tts[i], func);
            }
            );
            for (int i = 0; i < tts.Length; i++)
            {
                types.AddRange(tts[i]);
            }
            return types.ToArray();
            //return AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(a => a.GetTypes().Where(func))
            //    .ToArray();
        }

        private static void GetTypes(Assembly assembly, List<Type> types, Func<Type, bool> func)
        {
            var ts = assembly.GetTypes();

            for (int i = 0; i < ts.Length; i++)
            {
                if (func?.Invoke(ts[i]) ?? false)
                {
                    types.Add(ts[i]);
                }
            }
        }
    }
}
