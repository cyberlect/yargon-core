using System.Collections.Generic;

namespace Yargon.Core
{
    /// <summary>
    /// Consumes products to produce products.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Gets the types of input products.
        /// </summary>
        /// <value>A list of product types.</value>
        IReadOnlyList<IProductType> InputProductTypes { get; }

        /// <summary>
        /// Gets the types of output products.
        /// </summary>
        /// <value>A list of product types.</value>
        IReadOnlyList<IProductType> OutputProductTypes { get; }

        /// <summary>
        /// Applies the service to the specified input products.
        /// </summary>
        /// <param name="inputProducts">The input products.</param>
        /// <returns>The output products.</returns>
        IReadOnlyList<IProduct> Apply(IReadOnlyList<IProduct> inputProducts);
    }
}
