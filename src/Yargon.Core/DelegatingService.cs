using System;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Core
{
    /// <summary>
    /// Transforms input products into output products.
    /// </summary>
    /// <param name="inputProducts">The input products.</param>
    /// <returns>The output products.</returns>
    public delegate IReadOnlyList<IProduct> Transformer(IReadOnlyList<IProduct> inputProducts);

    /// <summary>
    /// Invokes a delegate.
    /// </summary>
    public sealed class DelegatingService : ServiceBase
    {
        /// <summary>
        /// The transformer delegate,
        /// </summary>
        private readonly Transformer transformer;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegatingService"/> class.
        /// </summary>
        /// <param name="transformer">The transformer delegate.</param>
        /// <param name="inputProductTypes">The input product types.</param>
        /// <param name="outputProductTypes">The output product types.</param>
        public DelegatingService(Transformer transformer, IReadOnlyList<IProductType> inputProductTypes, IReadOnlyList<IProductType> outputProductTypes)
            : base(inputProductTypes, outputProductTypes)
        {
            #region Contract
            if (transformer == null)
                throw new ArgumentNullException(nameof(transformer));
            #endregion

            this.transformer = transformer;
        }
        #endregion

        /// <inheritdoc />
        protected override IReadOnlyList<IProduct> DoApply(IReadOnlyList<IProduct> inputProducts)
        {
            return this.transformer(inputProducts);
        }
    }
}
