using System;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Core
{
    /// <summary>
    /// Base class for services.
    /// </summary>
    public abstract class ServiceBase : IService
    {
        /// <inheritdoc />
        public IReadOnlyList<IProductType> InputProductTypes { get; }
        
        /// <inheritdoc />
        public IReadOnlyList<IProductType> OutputProductTypes { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="inputProductTypes">The input product types.</param>
        /// <param name="outputProductTypes">The output product types.</param>
        protected ServiceBase(IEnumerable<IProductType> inputProductTypes, IEnumerable<IProductType> outputProductTypes)
        {
            #region Contract
            if (inputProductTypes == null)
                throw new ArgumentNullException(nameof(inputProductTypes));
            if (outputProductTypes == null)
                throw new ArgumentNullException(nameof(outputProductTypes));
            #endregion
            
            this.InputProductTypes = inputProductTypes.MakeSafeCopy(nameof(inputProductTypes));
            this.OutputProductTypes = outputProductTypes.MakeSafeCopy(nameof(outputProductTypes));
        }
        #endregion

        /// <inheritdoc />
        public IReadOnlyList<IProduct> Apply(IReadOnlyList<IProduct> inputProducts)
        {
            #region Contract
            if (inputProducts == null)
                throw new ArgumentNullException(nameof(inputProducts));
            if (!inputProducts.Select(p => p.Type).SequenceEqual(this.InputProductTypes))
                throw new ArgumentException("The input product types do not match.", nameof(inputProducts));
            #endregion

            var outputProducts = DoApply(inputProducts);

            if (!outputProducts.Select(p => p.Type).SequenceEqual(this.OutputProductTypes))
                throw new InvalidOperationException("The output product types do not match.");

            return outputProducts;
        }

        protected abstract IReadOnlyList<IProduct> DoApply(IReadOnlyList<IProduct> inputProducts);
    }
}
