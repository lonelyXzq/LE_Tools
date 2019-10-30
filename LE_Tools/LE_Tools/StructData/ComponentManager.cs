using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData
{
    class ComponentManager
    {
        private ComponentList[] componentLists;
        private int next;

        public ComponentManager()
        {
            componentLists = new ComponentList[EntityTypeManager.Count];
            for (int i = 0; i < componentLists.Length; i++)
            {
                componentLists[i] = new ComponentList(i);
            }
            next = 0;
        }

        public int AddEntity(int typeId)
        {
            if (typeId < 0 || typeId >= EntityTypeManager.Count)
            {

                LE_Log.Log.Error("TypeId error", "TypeId: {0} does not exists",typeId);
                return -1;
            }
            return componentLists[typeId].Add(ref next);
        }

        public void RemoveEntity(int typeId,int enttyId)
        {
            if (typeId < 0 || typeId >= EntityTypeManager.Count)
            {

                LE_Log.Log.Error("TypeId error", "TypeId: {0} does not exists", typeId);
                return ;
            }
            componentLists[typeId].Remove(enttyId);
        }

        class ComponentList
        {
            private readonly Dictionary<int, Component> datas;
            private readonly ComponentType type;
            private readonly Queue<int> unFill;
            public ComponentList(int typeId)
            {
                this.type = EntityTypeManager.Type_Es[typeId];
                datas = new Dictionary<int, Component>();
                unFill = new Queue<int>();
            }

            public int Add(ref int next)
            {
                if (unFill.Count > 0)
                {
                    int id = unFill.Dequeue();
                    int localId = datas[id].AddComponent();
                    if (!datas[id].DataIndex.IsFull)
                    {
                        unFill.Enqueue(id);
                    }
                    return Component.GetId(id,localId);
                }
                else
                {
                    var component = new Component(type, next);

                    datas.Add(next, component);
                    unFill.Enqueue(next);
                    next++;
                    int id = component.AddComponent();
                    return Component.GetId(next-1,id);
                }
            }

            public void Remove(int id)
            {
                int blockId = Component.GetBlockId(id);
                int localId = Component.GetLocalId(id);
                if(datas.TryGetValue(blockId,out Component component))
                {
                    component.RemoveComponent(localId);
                    unFill.Enqueue(blockId);
                }
            }

        }
    }
}
