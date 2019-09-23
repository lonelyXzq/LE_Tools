using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    [Obsolete]
    class DataChain<T> : IDataChain<T>
    {
        private readonly SList<T> datas;

        public DataChain(T defualtData= default)
        {
            datas = new SList<T>();
            datas.Add(defualtData);
        }

        public bool CheckData(int id)
        {
            return datas.Check(id);
        }

        public T[] FindData(Seek<T> seek)
        {
            return datas.FindData(seek);
        }

        public T[] GetAllData()
        {
            return datas.GetAllDatas();
        }

        public T GetData(int id)
        {
            if (CheckData(id))
            {
                return datas[id];
            }
            return default;
        }

        public int Add(T data)
        {
            return datas.Add(data);
        }

        public void RemoveData(int id)
        {
            datas.Remove(id);
        }
    }
}
