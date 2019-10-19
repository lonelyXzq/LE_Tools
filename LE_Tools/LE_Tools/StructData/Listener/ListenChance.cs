using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Tools.StructData.Listener
{
    [Flags]
    public enum ListenChance
    {
        OnCreate = 1,
        OnAdd = 2,
        OnChange = 4,
        OnRemove = 8,
        OnDestory = 16
    }


}
