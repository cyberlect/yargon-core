﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Core
{
    /// <summary>
    /// Manages and directs the services.
    /// </summary>
    public interface IOverseer
    {
        /// <summary>
        /// Requests a product.
        /// </summary>
        /// <param name="productType">The requested product type.</param>
        /// <param name="derivedFrom">The product from which the requested product must be (indirectly) derived.</param>
        /// <returns>The requested product.</returns>
        IProduct Request(IProductType productType, IProduct derivedFrom);

        /// <summary>
        /// Registers a service.
        /// </summary>
        /// <param name="service">The service to register.</param>
        void Register(IService service);
    }
}
