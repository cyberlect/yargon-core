using System.Collections.Generic;

namespace Yargon.Core
{
    /// <summary>
    /// Passes the products through without modification.
    /// </summary>
    public sealed class IdentityService : ServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityService"/> class.
        /// </summary>
        public IdentityService(IReadOnlyList<IProductType> productTypes)
            : base(productTypes, productTypes)
        {
            // Nothing to do.
        }
        #endregion

        /// <inheritdoc />
        protected override IReadOnlyList<IProduct> DoApply(IReadOnlyList<IProduct> inputProducts)
        {
            return inputProducts;
        }
    }
}
