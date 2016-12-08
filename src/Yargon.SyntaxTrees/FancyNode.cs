using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    public sealed class FancyNode : Node
    {
        /// <summary>
        /// Gets the node factory that created this node.
        /// </summary>
        /// <value>The factory that created this node.</value>
        private new FancyNodeFactory Factory => (FancyNodeFactory)base.Factory;

        /// <summary>
        /// Gets the green node backing this red node.
        /// </summary>
        /// <value>The underlying green node.</value>
        public new IFancyGreenNode GreenNode => (IFancyGreenNode)base.GreenNode;

        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent node;
        /// or <see langword="null"/> when this is the root node.</value>
        [CanBeNull]
        public new FancyNode Parent => (FancyNode)base.Parent;

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        public new IChildrenList<FancyNode> Children { get; }

        private readonly int baseCount;
        public int TotalCount => this.baseCount + this.GreenNode.Count;

        #region Constructors
        public FancyNode(FancyNodeFactory factory, IFancyGreenNode greenNode, [CanBeNull] FancyNode parent, int offset, int baseCount)
            : base(factory, greenNode, parent, offset)
        {
            this.Children = new SliceList<FancyNode>(base.Children);
            this.baseCount = baseCount;
        }
        #endregion
    }
}
