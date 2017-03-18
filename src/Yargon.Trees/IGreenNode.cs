using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A green tree node.
    /// </summary>
    /// <remarks>
    /// Green tree nodes store information about themselves
    /// and hold references to their child nodes.
    /// A green tree node may cache information derivable
    /// from its descendants, but must not contain any
    /// information that depends on its ancestors.
    /// </remarks>
    public interface IGreenNode
    {
        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        IReadOnlyList<IGreenNode> Children { get; }
    }
}
