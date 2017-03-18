using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A tree.
    /// </summary>
    /// <typeparam name="T">The type of tree nodes.</typeparam>
    /// <remarks>
    /// A tree is immutable and thread-safe.
    /// Any changes to this tree result in a new independent tree.
    /// </remarks>
    public class Tree<T>
        where T : INode
    {
        /// <summary>
        /// Gets the tree's root node.
        /// </summary>
        /// <value>The root node.</value>
        public T Root { get; }
    }
}
