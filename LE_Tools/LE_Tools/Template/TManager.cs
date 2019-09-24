using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Tools.Template
{
    class TManager<T> where T : class, ITemplate
    {
        private T[] datas;
        private int count;
        public int Count => count;
        public T[] Datas => datas;

        public TManager()
        {

        }

        public void Regiater(Type[] types)
        {
            count = types.Length;
            datas = new T[count];
            for (int i = 0; i < count; i++)
            {
                datas[i] = TypeManager.CreateInstance<T>(types[i]);
                int id = IdManager.IdDeliverer.CreateId<T>(types[i]);
                var _id = types[i].GetField("id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                if (_id == null)
                {
                    //TODO: Exception
                    //LE_Log.Log.Exception(new Exception(), "Template register fail", "templateType[name: {0}] does not have field : id !", types[i].FullName);
                }
                else
                {
                    _id.SetValue(datas[i], id);
                }
                var name = types[i].GetField("name", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                if (name == null)
                {
                    //TODO: Exception
                    //LE_Log.Log.Exception(new Exception(), "Template register fail", "templateType[name: {0}] does not have field : id !", types[i].FullName);
                }
                else
                {
                    name.SetValue(datas[i], types[i].FullName);
                }

                LE_Log.Log.Info("Template register", "Template[id: {0} , name: {1} ] register", datas[i].Id, datas[i].Name);
            }
        }
    }
}
