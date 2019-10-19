using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Listener
{
    class Listeners<T> where T : IData
    {
        public event ListenAction<T> OnCreate;
        public event ListenAction<T> OnAdd;
        public event ListenAction<T> OnChange;
        public event ListenAction<T> OnRemove;
        public event ListenAction<T> OnDestory;
    }
}
