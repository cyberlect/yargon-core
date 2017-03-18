using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.Trees
{
    /// <summary>
    /// A (red) syntax node.
    /// </summary>
    public interface ISyntaxNode : INode
    {
        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        new ISyntaxGreenNode GreenNode { get; }

        /// <summary>
        /// Gets the tree to which this node belongs.
        /// </summary>
        /// <value>The tree to which this node belongs;
        /// or <see langword="null"/> when this node doesn't belong to any tree.</value>
        [CanBeNull]
        new ISyntaxTree Tree { get; }

        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent node;
        /// or <see langword="null"/> when this is the root node.</value>
        [CanBeNull]
        new ISyntaxNode Parent { get; }

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        /// <remarks>
        /// This includes non-terminals, terminals, literals, and any trivia.
        /// </remarks>
        new IChildrenList<ISyntaxNode> Children { get; }

        /// <summary>
        /// Gets the abstract children of this node.
        /// </summary>
        /// <value>The abstract children of this node.</value>
        /// <remarks>
        /// This returns only the non-terminals and non-literal terminals.
        /// </remarks>
        IReadOnlyList<ISyntaxNode> AbstractChildren { get; }

        /// <summary>
        /// Gets the zero-based text offset of this node.
        /// </summary>
        /// <value>The zero-based text offset.</value>
        int Offset { get; }

        /// <summary>
        /// Gets the text width of this node.
        /// </summary>
        /// <value>The text width.</value>
        int Width { get; }
    }
}
