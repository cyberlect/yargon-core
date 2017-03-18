using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A tree.
    /// </summary>
    /// <remarks>
    /// A tree is immutable and thread-safe.
    /// Any changes to this tree result in a new independent tree.
    /// </remarks>
    public interface ITree
    {
        /// <summary>
        /// Gets the tree's root node.
        /// </summary>
        /// <value>The root node.</value>
        INode Root { get; }
    }
}
