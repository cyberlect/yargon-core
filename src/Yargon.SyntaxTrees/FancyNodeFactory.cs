using System;

namespace Yargon.SyntaxTrees
{
    public sealed class FancyNodeFactory : NodeFactory
    {
        public override Node Create(IGreenNode greenNode, Node parent, int index)
        {
            return Create((IFancyGreenNode)greenNode, (FancyNode)parent, index);
        }

        public override Node Create(IGreenNode greenNode)
        {
            return Create((IFancyGreenNode)greenNode);
        }

        /// <inheritdoc />
        public FancyNode Create(IFancyGreenNode greenNode, FancyNode parent, int index)
        {
            #region Contract
            if (greenNode == null)
                throw new ArgumentNullException(nameof(greenNode));
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (index < 0 || index >= parent.Children.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int baseCount = CalculateCaseCount(parent, index);
            int offset = CalculateOffset(parent, index);
            return new FancyNode(this, greenNode, parent, offset, baseCount);
        }

        /// <inheritdoc />
        public FancyNode Create(IFancyGreenNode greenNode)
        {
            #region Contract
            if (greenNode == null)
                throw new ArgumentNullException(nameof(greenNode));
            #endregion

            return new FancyNode(this, greenNode, null, 0, 0);
        }
        
        private int CalculateCaseCount(FancyNode parent, int index)
        {
            #region Contract
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (index < 0 || index >= parent.Children.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int c = 0;
            for (int i = index - 1; i >= 0; i--)
            {
                // Add the green node's width to the offset.
                var greenNode = (IFancyGreenNode)parent.GreenNode.Children[i];
                c += greenNode.Count;
            }
            
            return c;
        }
    }
}
