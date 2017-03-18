using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.Trees
{
    /// <summary>
    /// A (red) tagged node.
    /// </summary>
    public interface ITaggedNode : INode
    {
        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        new ITaggedGreenNode GreenNode { get; }

        /// <summary>
        /// Gets the tree to which this node belongs.
        /// </summary>
        /// <value>The tree to which this node belongs;
        /// or <see langword="null"/> when this node doesn't belong to any tree.</value>
        [CanBeNull]
        new ITaggedTree Tree { get; }

        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent node;
        /// or <see langword="null"/> when this is the root node.</value>
        [CanBeNull]
        new ITaggedNode Parent { get; }

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        new IChildrenList<ITaggedNode> Children { get; }

        /// <summary>
        /// Gets a collection of tags.
        /// </summary>
        /// <value>A collection of tags.</value>
        IReadOnlyCollection<object> Tags { get; }
    }
}
