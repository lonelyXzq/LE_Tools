using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace LE_Tools.Fsm
{
    public static class FsmManager
    {
        private static List<MethodInfo> methodInfos = new List<MethodInfo>();

        static FsmManager()
        {

        }

        public static void Release()
        {
            methodInfos = null;
        }

        private struct Node
        {
            public MethodInfo methodInfo;
            public FsmActionInfoAttribute infoAttribute;

            public Node(MethodInfo methodInfo, FsmActionInfoAttribute infoAttribute)
            {
                this.methodInfo = methodInfo;
                this.infoAttribute = infoAttribute;
            }
        }

        public static Dictionary<string, FsmState<T>> GetStates<T>() where T : IFsmOwner
        {
            Dictionary<string, FsmState<T>> datas = new Dictionary<string, FsmState<T>>();

            MethodInfo[] infos = methodInfos.Where(a => a.GetCustomAttribute<FsmActionInfoAttribute>().Type == typeof(T)).ToArray();
            for (int i = 0; i < infos.Length; i++)
            {
                var t = infos[i].GetCustomAttribute<FsmActionInfoAttribute>();
                if (t.Mark)
                {
                    //if()
                }
            }
            return datas;
        }



        public static void Init()
        {
            var _datas = TypeManager.GetTypes((a) => a.GetCustomAttribute<FsmRegisterAttribute>() != null);
            //Register(_datas);
        }

        //public static void Register(Type[] types)
        //{
        //    List<MethodInfo> infos = new List<MethodInfo>();
        //    Dictionary<string, List<Node>> fsmStates = new Dictionary<string, List<Node>>();
        //    for (int i = 0; i < types.Length; i++)
        //    {
        //        Console.WriteLine(types[i].FullName);
        //        infos.AddRange(types[i].GetMethods());
        //        types[i].GetMethods(BindingFlags.Static);
        //    }
        //    int i0 = 0;
        //    Console.WriteLine(infos.Count);
        //    for (int i = 0; i < infos.Count; i++)
        //    {
        //        FsmActionInfoAttribute t;
        //        Console.WriteLine(i);
        //        Console.WriteLine(infos[i].Name);
        //        try
        //        {
        //            t = infos[i].GetCustomAttribute<FsmActionInfoAttribute>();
        //        }
        //        catch (Exception)
        //        {
        //            break;
        //        }
        //        if (t == null)
        //        {
        //            break;
        //        }
        //        if (fsmStates.TryGetValue(t.Name, out List<Node> _nodes))
        //        {
        //            _nodes.Add(new Node(infos[i], t));
        //        }
        //        else
        //        {
        //            List<Node> nodes = new List<Node>();
        //            nodes.Add(new Node(infos[i], t));
        //            fsmStates.Add(t.Name, nodes);
        //            FsmState<T> state = new FsmState<T>(t.Name, i0);
        //            fsms.Add(t.Name, state);
        //            i0++;
        //        }
        //    }
        //    int n = fsmStates.Count;
        //    foreach (var fsmState in fsmStates)
        //    {
        //        for (int i = 0; i < fsmState.Value.Count; i++)
        //        {
        //            var state = fsms[fsmState.Key];
        //            state.SetChanges(new FsmEventHandler<T>[n]);
        //            var t = fsmState.Value[i];
        //            FsmEventHandler<T> ac;
        //            try
        //            {

        //                ac = (FsmEventHandler<T>)Delegate.CreateDelegate(typeof(FsmEventHandler<T>), t.methodInfo);
        //            }
        //            catch (Exception e)
        //            {

        //                LE_Log.Log.Error("FsmEventHandler Error", "FsmEventHandler[owner: {0} type: {1} ] is invalid!\n     {2}"
        //                    , typeof(T).FullName, t.methodInfo.Name, e.Message);
        //                break;
        //                //throw;
        //            }
        //            if (ac == null)
        //            {
        //                break;
        //            }
        //            if (t.infoAttribute.Mark)
        //            {
        //                if (fsms.TryGetValue(t.infoAttribute.ToName, out FsmState<T> to))
        //                {
        //                    state.SubscribeChange(to.Id, ac);
        //                }
        //            }
        //            else
        //            {
        //                state.Subscribe(t.infoAttribute.Chance, ac);
        //            }
        //        }
        //        i0++;
        //    }
        //    fsm = new Fsm<T>(fsms);
        //}
    }
}
