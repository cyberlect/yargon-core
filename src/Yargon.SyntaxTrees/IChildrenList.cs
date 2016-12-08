using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A list of child nodes.
    /// </summary>
    /// <typeparam name="T">The type of nodes.</typeparam>
    public interface IChildrenList<T> : IReadOnlyList<T>
        where T : Node
    {
        /// <summary>
        /// Attempts to get the red child with the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the child.</param>
        /// <param name="child">The red child; or the default value if not cached.</param>
        /// <returns><see langword="true"/> when the child was found;
        /// otherwise, <see langword="false"/>.</returns>
        bool TryGet(int index, out T child);
    }
}
