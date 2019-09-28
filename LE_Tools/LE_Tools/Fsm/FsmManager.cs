using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace LE_Tools.Fsm
{
    public static class FsmManager
    {


        public static void Init()
        {
            var types = TypeManager.GetTypes(a => a.GetInterfaces().Contains(typeof(IFsmProvider)));
            for (int i = 0; i < types.Length; i++)
            {
                var t = (IFsmProvider)TypeManager.CreateInstance(types[i]);
                t.Init();
            }
        }
        
    }
}
