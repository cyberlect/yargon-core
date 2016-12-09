using System;
using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A (red) syntax tree node.
    /// </summary>
    public partial class Node : INode
    {
        /// <summary>
        /// Gets the node factory that created this node.
        /// </summary>
        /// <value>The factory that created this node.</value>
        public INodeFactory Factory { get; }

        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        public IGreenNode GreenNode { get; }

        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent node;
        /// or <see langword="null"/> when this is the root node.</value>
        [CanBeNull]
        public INode Parent { get; }

        /// <summary>
        /// Gets the zero-based text offset of this node.
        /// </summary>
        /// <value>The zero-based text offset.</value>
        public int Offset { get; }

        /// <summary>
        /// Gets the text width of this node.
        /// </summary>
        /// <value>The text width.</value>
        public int Width => this.GreenNode.Width;

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        public IChildrenList<INode> Children { get; }

        /// <inheritdoc />
        IChildrenList<INode> INode.Children => this.Children;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="factory">The node factory that created this node.</param>
        /// <param name="greenNode">The green node backing this node.</param>
        /// <param name="parent">The parent node; or <see langword="null"/>.</param>
        /// <param name="offset">The text offset of this node.</param>
        protected internal Node(INodeFactory factory, IGreenNode greenNode, [CanBeNull] Node parent, int offset)
        {
            #region Contract
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            if (greenNode == null)
                throw new ArgumentNullException(nameof(greenNode));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            #endregion

            this.Factory = factory;
            this.GreenNode = greenNode;
            this.Parent = parent;
            this.Offset = offset;
            this.Children = new ChildrenList(this);
        }
        #endregion
    }
}
