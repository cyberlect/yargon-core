using System.Collections.Generic;

namespace Yargon.Trees
{
    /// <summary>
    /// A list of child nodes.
    /// </summary>
    /// <typeparam name="T">The type of nodes.</typeparam>
    public interface IChildrenList<out T> : IReadOnlyList<T>
        where T : INode
    {
        /// <summary>
        /// Attempts to get the red child with the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the child.</param>
        /// <returns>The red child; or the default value of <typeparamref name="T"/>
        /// if not cached.</returns>
        /// <remarks>
        /// To get the child node of a node, use the indexer.
        /// </remarks>
        T TryGet(int index);
    }
}
