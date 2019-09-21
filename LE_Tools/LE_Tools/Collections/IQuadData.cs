using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_Tools.Collections
{
    public interface IQuadData
    {
        Vector2Int Position { get; }
        bool Equals(IQuadData quadData);

    }
}
