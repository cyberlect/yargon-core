using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Trees
{
    /// <summary>
    /// A green syntax node.
    /// </summary>
    public interface ISyntaxGreenNode : IGreenNode
    {
        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The children of this node.</value>
        /// <remarks>
        /// This includes non-terminals, terminals, literals, and any trivia.
        /// </remarks>
        new IReadOnlyList<ISyntaxGreenNode> Children { get; }

        /// <summary>
        /// Gets the abstract children of this node.
        /// </summary>
        /// <value>The abstract children of this node.</value>
        /// <remarks>
        /// This returns only the non-terminals and non-literal terminals.
        /// </remarks>
        IReadOnlyList<ISyntaxGreenNode> AbstractChildren { get; }

        /// <summary>
        /// Gets the text width of this node.
        /// </summary>
        /// <value>The text width.</value>
        int Width { get; }
    }
}
