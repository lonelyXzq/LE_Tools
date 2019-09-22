using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Tools.Fsm
{
    public static class FsmManager<T> where T : IFsmOwner
    {
        private static Fsm<T> fsm;

        static FsmManager()
        {

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

        public static void Init(Type[] types)
        {
            List<MethodInfo> infos = new List<MethodInfo>();
            Dictionary<string, List<Node>> fsmStates = new Dictionary<string, List<Node>>();
            Dictionary<string, FsmState<T>> fsms = new Dictionary<string, FsmState<T>>();
            for (int i = 0; i < types.Length; i++)
            {
                infos.AddRange(types[i].GetMethods());
            }
            int i0 = 0;
            for (int i = 0; i < infos.Count; i++)
            {
                FsmActionInfoAttribute t;
                try
                {
                    t = infos[i].GetCustomAttribute<FsmActionInfoAttribute>();
                }
                catch (Exception)
                {
                    break;
                }
                if (t == null)
                {
                    break;
                }
                if (fsmStates.TryGetValue(t.Name, out List<Node> _nodes))
                {
                    _nodes.Add(new Node(infos[i], t));
                }
                else
                {
                    List<Node> nodes = new List<Node>();
                    nodes.Add(new Node(infos[i], t));
                    fsmStates.Add(t.Name, nodes);
                    FsmState<T> state = new FsmState<T>(t.Name, i0);
                    fsms.Add(t.Name, state);
                    i0++;
                }
            }
            int n = fsmStates.Count;
            foreach (var fsmState in fsmStates)
            {
                for (int i = 0; i < fsmState.Value.Count; i++)
                {
                    var state = fsms[fsmState.Key];
                    state.SetChanges(new FsmEventHandler<T>[n]);
                    var t = fsmState.Value[i];
                    FsmEventHandler<T> ac;
                    try
                    {
                        ac = (FsmEventHandler<T>)t.methodInfo.CreateDelegate(typeof(FsmEventHandler<T>));
                    }
                    catch (Exception)
                    {

                        LE_Log.Log.Error("FsmEventHandler Error", "FsmEventHandler[owner: {0} type: {1} ] is invalid! "
                            , typeof(T).FullName, t.methodInfo.Name);
                        break;
                        //throw;
                    }
                    if (ac == null)
                    {
                        break;
                    }
                    if (t.infoAttribute.Mark)
                    {
                        if(fsms.TryGetValue(t.infoAttribute.ToName,out FsmState<T> to))
                        {
                            state.SubscribeChange(to.Id, ac);
                        }   
                    }
                    else
                    {
                        state.Subscribe(t.infoAttribute.Chance, ac);
                    }
                }
                i0++;
            }
            fsm = new Fsm<T>(fsms);
        }
    }
}
