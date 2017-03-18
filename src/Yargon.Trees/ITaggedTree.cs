using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A tagged tree.
    /// </summary>
    public interface ITaggedTree : ITree
    {
        /// <summary>
        /// Gets the tree's root node.
        /// </summary>
        /// <value>The root node.</value>
        new ITaggedNode Root { get; }
    }
}
