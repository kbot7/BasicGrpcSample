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
                Customer = request.Customer,
                DateTimePlaced = request.DateTimePlaced,
                Skus = request.Skus
            };
            return Task.FromResult(order);
        }

        public Task<Order> GetOrderAsync(GetOrderRequest request)
        {
            // Create customer with circular reference
            var cust = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.UtcNow
            };
            cust.Orders = new List<Order>
            {
                new Order
                {
                    OrderId = "abc123",
                    DateTimePlaced = DateTime.UtcNow,
                    Customer = cust,
                }
            };

            var order = new Order
            {
                OrderId = request.OrderId,
                Customer = cust,
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
                    Customer = new Customer
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = DateTime.UtcNow
                    },
                    DateTimePlaced = DateTime.Now,
                    Skus = new List<string> { "a1", "a2" }
                });
            }

            return Task.FromResult(orders);
        }
    }
}
