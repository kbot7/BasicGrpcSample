using BasicGrpcSample.Protos;
using BasicGrpcSample.Protos.Product;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicGrpcSample.Server.Services
{
    public class ProductService : Protos.Product.ProductService.ProductServiceBase
    {
        public override Task<Product> GetProduct(ProductRequest request, ServerCallContext context)
        {
            var product = new Product
            {
                Name = "Apples",
                DateAdded = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
            };
            return Task.FromResult(product);
        }
    }
}
