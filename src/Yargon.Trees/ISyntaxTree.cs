using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A syntax tree.
    /// </summary>
    public interface ISyntaxTree : ITree
    {
        /// <summary>
        /// Gets the tree's root node.
        /// </summary>
        /// <value>The root node.</value>
        new ISyntaxNode Root { get; }

        /// <summary>
        /// Gets the resource whose syntax tree this is.
        /// </summary>
        /// <value>A resource URI.</value>
        Uri Resource { get; }
    }
}
