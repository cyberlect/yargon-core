using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Yargon.SyntaxTrees
{
    public sealed class TreePath
    {
        /// <summary>
        /// Gets the zero-based child index.
        /// </summary>
        /// <value>The zero-baed child index.</value>
        public int Index { get; }

        /// <summary>
        /// Gets the parent path.
        /// </summary>
        /// <value>The parent path; or <see langword="null"/>.</value>
        [CanBeNull]
        public TreePath Parent { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TreePath"/> class.
        /// </summary>
        public TreePath([CanBeNull] TreePath parent, int index)
        {
            #region Contract
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            this.Index = index;
            this.Parent = parent;
        }
        #endregion

        /// <inheritdoc />
        public override string ToString()
        {
            return (this.Parent?.ToString() ?? "") + this.Index + "/";
        }
    }
}
