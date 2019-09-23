using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.IdManager
{
    static class IdDeliverer
    {
        private static readonly Dictionary<string, int> ids = new Dictionary<string, int>();

        private static readonly Dictionary<string, long> baseIds = new Dictionary<string, long>();


        private static long nextBaseId = 0;

        public static int CreateId<T, TD>() where TD : T
        {
            if (ids.ContainsKey(typeof(TD).FullName))
            {

                //LE_Log.Log.Error("IdAlreadyExistsError", "Type: {0} already does not exists", typeof(TD).FullName);
                return -1;
            }
            if (baseIds.TryGetValue(typeof(T).FullName, out long longId))
            {
                int tid = (int)longId;
                baseIds[typeof(T).FullName] = longId + 1;
                ids.Add(typeof(TD).FullName, tid);
                return tid;
            }
            else
            {
                baseIds.Add(typeof(T).FullName, (nextBaseId << 32) + 1);
                ids.Add(typeof(TD).FullName, 0);
                nextBaseId++;
                return 0;
            }

        }

        public static int GetId<TD>()
        {
            if (ids.TryGetValue(typeof(TD).FullName, out int id))
            {
                return id;
            }
            else
            {
                LE_Log.Log.Error("IdNotExistsError", "Type: {0} does not exists", typeof(TD).FullName);
                return -1;
            }
        }

        public static int GetCount<T>()
        {
            if (baseIds.TryGetValue(typeof(T).FullName, out long id))
            {
                return (int)id;
            }
            else
            {
                LE_Log.Log.Error("BaseIdNotExistsError", "BaseType: {0} does not exists", typeof(T).FullName);
                return -1;
            }
        }

        public static int GetBaseId<T>()
        {
            if (baseIds.TryGetValue(typeof(T).FullName, out long id))
            {
                return (int)(id >> 32);
            }
            else
            {
                LE_Log.Log.Error("BaseIdNotExistsError", "BaseType: {0} does not exists", typeof(T).FullName);
                return -1;
            }
        }

        public static long GetLongId<T, TD>() where TD : T
        {
            if (baseIds.TryGetValue(typeof(T).FullName, out long bid))
            {
                if (ids.TryGetValue(typeof(TD).FullName, out int id))
                {
                    return ((long)((ulong)bid & 0xffffffff00000000)) + id;
                }
                else
                {
                    LE_Log.Log.Error("IdNotExistsError", "BaseType: {0} [Type: {1} ] does not exists", typeof(T).FullName, typeof(TD).FullName);
                    return -1;
                }
            }
            else
            {
                LE_Log.Log.Error("IdNotExistsError", "Type: {0} [BaseType: {1} ] does not exists", typeof(TD).FullName, typeof(T).FullName);
                return -1;
            }
        }
    }
}
