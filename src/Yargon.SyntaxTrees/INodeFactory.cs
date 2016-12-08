using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A red node factory.
    /// </summary>
    public interface INodeFactory
    {
        /// <summary>
        /// Creates a red node for the specified child green node.
        /// </summary>
        /// <param name="greenNode">The green node.</param>
        /// <param name="parent">The parent red node.</param>
        /// <param name="index">The zero-based index of the child node.</param>
        /// <returns>The corresponding created red node.</returns>
        Node Create(IGreenNode greenNode, Node parent, int index);

        /// <summary>
        /// Creates a red node for the specified green node.
        /// </summary>
        /// <param name="greenNode">The green node.</param>
        /// <returns>The corresponding created red node.</returns>
        Node Create(IGreenNode greenNode);
    }
}
