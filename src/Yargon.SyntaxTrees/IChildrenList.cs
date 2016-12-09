using System.Collections.Generic;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A list of child nodes.
    /// </summary>
    /// <typeparam name="T">The type of nodes.</typeparam>
    public interface IChildrenList<out T> : IReadOnlyList<T>
        where T : class, INode
    {
        /// <summary>
        /// Attempts to get the red child with the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the child.</param>
        /// <returns>The red child; or <see langword="null"/> if not cached.</returns>
        T TryGet(int index);
    }
}
