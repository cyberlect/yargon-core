using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A green tagged node.
    /// </summary>
    public interface ITaggedGreenNode : IGreenNode
    {
        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        new IReadOnlyList<ITaggedGreenNode> Children { get; }
        
        /// <summary>
        /// Gets a collection of tags.
        /// </summary>
        /// <value>A collection of tags.</value>
        IReadOnlyCollection<object> Tags { get; }

        /// <summary>
        /// Returns whether the specified tag may be present in this node's subtree.
        /// </summary>
        /// <param name="tag">The tag to look for.</param>
        /// <returns><see langword="true"/> when the specified tag may be found in this node
        /// or the descendants of this node; otherwise, <see langword="false"/> when
        /// the tag is sure not to occur in this node or any of its descendants.</returns>
        bool MayHaveTagInSubtree(object tag);
    }
}
