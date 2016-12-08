using System;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Core
{
    /// <summary>
    /// Produces products.
    /// </summary>
    public abstract class SourceService : ServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceService"/> class.
        /// </summary>
        /// <param name="outputProductTypes">The output product types.</param>
        protected SourceService(IReadOnlyList<IProductType> outputProductTypes)
            : base(Enumerable.Empty<IProductType>(), outputProductTypes)
        {
            // Nothing to do.
        }
        #endregion

        /// <inheritdoc />
        protected sealed override IReadOnlyList<IProduct> DoApply(IReadOnlyList<IProduct> inputProducts)
        {
            return Produce();
        }

        /// <summary>
        /// Produces products.
        /// </summary>
        /// <returns>The output products.</returns>
        protected abstract IReadOnlyList<IProduct> Produce();
    }
}
