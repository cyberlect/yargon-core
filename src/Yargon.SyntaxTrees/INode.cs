using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A (red) syntax tree node.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets the node factory that created this node.
        /// </summary>
        /// <value>The factory that created this node.</value>
        INodeFactory Factory { get; }

        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        IGreenNode GreenNode { get; }

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
