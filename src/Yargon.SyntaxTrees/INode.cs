using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A (red) tree node.
    /// </summary>
    /// <remarks>
    /// Red tree nodes know about both their children and their parent,
    /// and information about the node itself, derivable from its
    /// descendants, and derivable from its ancestors.
    /// </remarks>
    public interface INode
    {
        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent node;
        /// or <see langword="null"/> when this is the root node.</value>
        [CanBeNull]
        INode Parent { get; }

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        IReadOnlyList<INode> Children { get; }
    }
}
