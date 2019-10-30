using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LE_Tools.Collections;

namespace LE_Tools.StructData
{
    class Component
    {
        public static int GetId(int blockId, int id)
        {
            return blockId * BlockSize + id;
        }

        public static int GetBlockId(int id)
        {
            return id / BlockSize;
        }

        public static int GetLocalId(int id)
        {
            return id % BlockSize;
        }

        private readonly DataIndex dataIndex;
        private readonly ComponentType componentType;
        public static int BlockSize = 64;
        private readonly BlockNode[] nodes;
        private readonly int id;

        public int Id => id;

        internal DataIndex DataIndex => dataIndex;

        public Component(ComponentType componentType, int id)
        {
            this.id = id;
            dataIndex = new DataIndex(BlockSize);
            this.componentType = componentType;
            nodes = new BlockNode[componentType.DataCount];
            for (int i = 0; i < componentType.DataCount; i++)
            {
                nodes[i] = new BlockNode(DataManager.DataSize[i], BlockSize);
            }
        }

        internal int AddComponent()
        {
            return dataIndex.AddData();
        }

        internal void RemoveComponent(int id)
        {
            dataIndex.RemoveData(id);
        }

        internal void SetData<T>(int id, T data) where T : struct, IData
        {
            if (!dataIndex.Check(id))
            {
                LE_Log.Log.Error("invalid id", "component[id: {0},name: {1}] does not have id: {2}",
                    componentType.Id, componentType.Name, Component.GetId(this.id, id));
                return;
            }
            int m = componentType.MappingArray.Get(DataInfo<T>.Id);
            if (m == -1)
            {
                LE_Log.Log.Error("invalid data type", "component[id: {0},name: {1}] does not have data type: {2}",
                    componentType.Id, componentType.Name, typeof(T).FullName);
                return;
            }
            nodes[m].CreateSpan<T>()[id] = data;
        }

        internal T GetData<T>(int id) where T : struct, IData
        {
            if (!dataIndex.Check(id))
            {
                LE_Log.Log.Error("invalid id", "component[id: {0},name: {1}] does not have id: {2}",
                    componentType.Id, componentType.Name, Component.GetId(this.id, id));
                return new T();
            }
            int m = componentType.MappingArray.Get(DataInfo<T>.Id);
            if (m == -1)
            {
                LE_Log.Log.Error("invalid data type", "component[id: {0},name: {1}] does not have data type: {2}",
                    componentType.Id, componentType.Name, typeof(T).FullName);
                return new T();
            }
            return nodes[m].CreateSpan<T>()[id];
        }

    }
}
