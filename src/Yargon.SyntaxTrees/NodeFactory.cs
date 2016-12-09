using System;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// Node factory.
    /// </summary>
    public class NodeFactory : INodeFactory
    {
        /// <inheritdoc />
        public virtual INode Create(IGreenNode greenNode, INode parent, int index)
        {
            #region Contract
            if (greenNode == null)
                throw new ArgumentNullException(nameof(greenNode));
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (index < 0 || index >= parent.Children.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (!(parent is Node))
                throw new ArgumentException("Parent is not a Node.", nameof(parent));
            #endregion

            int offset = CalculateOffset((Node)parent, index);
            return new Node(this, greenNode, (Node)parent, offset);
        }

        /// <inheritdoc />
        public virtual INode Create(IGreenNode greenNode)
        {
            #region Contract
            if (greenNode == null)
                throw new ArgumentNullException(nameof(greenNode));
            #endregion
            
            return new Node(this, greenNode, null, 0);
        }

        /// <summary>
        /// Calculates the offset of the child with the specified index.
        /// </summary>
        /// <param name="parent">The parent node.</param>
        /// <param name="index">The zero-based index of the child.</param>
        /// <returns>The zero-based offset.</returns>
        protected int CalculateOffset(Node parent, int index)
        {
            #region Contract
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (index < 0 || index >= parent.Children.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int span = 0;
            for (int i = index - 1; i >= 0; i--)
            {
                // Add the green node's width to the offset.
                var greenNode = parent.GreenNode.Children[i];
                span += greenNode.Width;

                // If we find a red node,
                // return the final offset immediately.
                var redNode = parent.Children.TryGet(i);
                if (redNode != null)
                    return redNode.Offset + span;
            }

            // We didn't find a red child node.
            return parent.Offset + span;
        }
    }
}
