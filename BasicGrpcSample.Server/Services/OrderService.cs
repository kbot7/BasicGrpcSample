using BasicGrpcSample.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicGrpcSample.Server.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                DateTimePlaced = request.DateTimePlaced,
                Skus = request.Skus
            };
            return Task.FromResult(order);
        }

        public Task<Order> GetOrderAsync(GetOrderRequest request)
        {
            var order = new Order
            {
                OrderId = request.OrderId,
                CustomerId = "cust123",
                DateTimePlaced = DateTime.Now,
                Skus = new List<string> { "a1", "a2" }
            };
            return Task.FromResult(order);
        }

        public Task<List<Order>> GetOrdersAsync(GetOrdersRequest request)
        {
            var orders = new List<Order>();
            foreach (var orderId in request.OrderIds)
            {
                orders.Add(new Order
                {
                    OrderId = orderId,
                    CustomerId = "cust123",
                    DateTimePlaced = DateTime.Now,
                    Skus = new List<string> { "a1", "a2" }
                });
            }

            return Task.FromResult(orders);
        }
    }
}
