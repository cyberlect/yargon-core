using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.Trees
{
    /// <summary>
    /// A (red) tree node.
    /// </summary>
    /// <remarks>
    /// Red tree nodes may cache information derived from
    /// the underlying green node, the node's descendants.
    /// and the node's ancestors. However, red nodes contain
    /// no information that can not be reconstructed from
    /// the green tree or the red node's position in the tree.
    /// </remarks>
    public interface INode
    {
        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        IGreenNode GreenNode { get; }

        /// <summary>
        /// Gets the tree to which this node belongs.
        /// </summary>
        /// <value>The tree to which this node belongs;
        /// or <see langword="null"/> when this node doesn't belong to any tree.</value>
        [CanBeNull]
        ITree Tree { get; }

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
        IChildrenList<INode> Children { get; }
    }
}
