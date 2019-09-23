using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.Collections
{
    //TODO: debug SList
    class SList<T> : ISList<T>
    {
        private readonly List<ListData> datas;
        private int addPoint;
        private int lastPoint;

        private int count;
        private int maxLength;

        public SList()
        {
            datas = new List<ListData>();
            addPoint = -1;
            lastPoint = -1;
        }

        public T this[int index]
        {
            get
            {
                return datas[index].Data;
            }
            set
            {
                datas[index].Data = value;
            }
        }

        public int Count => count;
        public int Length => maxLength;

        public int Add(T data)
        {
            int re;
            if (addPoint < 0)
            {
                datas.Add(new ListData(-1, data));
                re = count;
                count++;
                maxLength++;
            }
            else
            {
                re = addPoint;
                ListData listData = datas[addPoint];
                listData.Data = data;
                addPoint = listData.Id;
                listData.Id = -1;
                count++;
            }
            return re;
        }

        public T GetData(int id)
        {
            if (Check(id))
            {
                return datas[id].Data;
            }
            return default;
        }

        //public int AddId()
        //{
        //    int re;
        //    if (addPoint < 0)
        //    {
        //        datas.Add(new ListData(-1, default));
        //        re = count;
        //        count++;
        //        maxLength++;
        //    }
        //    else
        //    {
        //        re = addPoint;
        //        ListData listData = datas[addPoint];
        //        listData.Data = default;
        //        addPoint = listData.Id;
        //        listData.Id = -1;
        //        count++;
        //    }
        //    return re;
        //}

        public bool Check(int index)
        {
            if (index < 0 || index >= maxLength)
            {
                return false;
            }
            else if (datas[index].Id == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            datas.Clear();
            addPoint = -1;
            lastPoint = -1;
            count = 0;
            maxLength = 0;
        }

        public T[] FindData(Seek<T> seek)
        {
            List<T> re = new List<T>();
            for (int i = 0; i < maxLength; i++)
            {
                if (datas[i].Id == -1 && seek(datas[i].Data))
                {
                    re.Add(datas[i].Data);
                }
            }
            return re.ToArray();
        }

        public T[] GetAllDatas()
        {
            T[] re = new T[count];
            int j = 0;
            for (int i = 0; i < maxLength; i++)
            {
                if (datas[i].Id == -1)
                {
                    re[j] = datas[i].Data;
                    j++;
                }
            }
            return re;
        }

        public void Remove(int index)
        {
            if (!Check(index))
            {
                return;
            }
            //if (index == maxLength - 1)
            //{
            //    datas.RemoveAt(index);
            //    count--;
            //    maxLength--;
            //    return;
            //}
            datas[index].Data = default;
            datas[index].Id = -2;
            count--;
            if (lastPoint > -1)
            {
                datas[lastPoint].Id = index;
            }
            else
            {
                addPoint = index;
            }
            lastPoint = index;
        }

        public class ListData
        {
            private int id;
            private T data;

            public ListData(int id, T data)
            {
                this.id = id;
                this.data = data;
            }

            public int Id { get => id; set => id = value; }
            public T Data { get => data; set => data = value; }
        }
    }
}
