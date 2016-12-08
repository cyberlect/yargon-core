using System;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Core
{
    /// <summary>
    /// Consumes products.
    /// </summary>
    public abstract class SinkService : ServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SinkService"/> class.
        /// </summary>
        /// <param name="inputProductTypes">The input product types.</param>
        protected SinkService(IReadOnlyList<IProductType> inputProductTypes)
            : base(inputProductTypes, Enumerable.Empty<IProductType>())
        {
            // Nothing to do.
        }
        #endregion

        /// <inheritdoc />
        protected sealed override IReadOnlyList<IProduct> DoApply(IReadOnlyList<IProduct> inputProducts)
        {
            Consume(inputProducts);
            return (IReadOnlyList<IProduct>)Enumerable.Empty<IProduct>();
        }

        /// <summary>
        /// Produces products.
        /// </summary>
        /// <param name="inputProducts">The input products.</param>
        protected abstract void Consume(IReadOnlyList<IProduct> inputProducts);
    }
}
