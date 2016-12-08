using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Core
{
    /// <summary>
    /// A compiler product.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the type of product.
        /// </summary>
        /// <value>The type of product.</value>
        IProductType Type { get; }
    }
}
