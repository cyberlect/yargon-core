using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.SyntaxTrees
{
    public interface IFancyGreenNode : IGreenNode
    {
        int Count { get; }
    }
}
