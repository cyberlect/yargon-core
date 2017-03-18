using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A red node factory.
    /// </summary>
    public interface INodeFactory
    {
        /// <summary>
        /// Creates a red node for the specified child green node.
        /// </summary>
        /// <param name="parent">The parent red node.</param>
        /// <param name="index">The zero-based index of the child node.</param>
        /// <returns>The corresponding created red node.</returns>
        INode Create(INode parent, int index);

        /// <summary>
        /// Creates a red node for the specified green node.
        /// </summary>
        /// <param name="tree">The tree to which the node belongs.</param>
        /// <param name="greenNode">The green node.</param>
        /// <returns>The corresponding created red node.</returns>
        /// <remarks>
        /// Use this overload only for a tree's root red node.
        /// </remarks>
        INode Create(ITree tree, IGreenNode greenNode);
    }
}
