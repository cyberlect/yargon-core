﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.SyntaxTrees
{
    /// <summary>
    /// A green tree node.
    /// </summary>
    /// <remarks>
    /// Green tree nodes only know their children,
    /// and information about the node itself
    /// or information derivable from its descendants.
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
