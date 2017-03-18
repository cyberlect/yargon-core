# Yargon.Core

The core library contains the infrastructure for a compiler built from services, to allow Compiler-as-a-Service (CaaS).

A service, which implements the `IService` interface, produces some products when invoked. The service in turn needs some other products from other services. Therefore, requesting a particular product will invoke all services needed to ultimately produce that product.

The products are cached, such that when some data changes not all services need to recalculate.

## Products
A product is uniquely and deterministically identified, so that services can request it and produce them.

A unique way to describe a product is by the name of the service that created it, and the names of the inputs to the service that created it.