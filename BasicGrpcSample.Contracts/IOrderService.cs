using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BasicGrpcSample.Contracts
{
    [ServiceContract(Name = "OrderService")]
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(GetOrderRequest request);
        Task<Order> CreateOrderAsync(CreateOrderRequest request);
        Task<List<Order>> GetOrdersAsync(GetOrdersRequest request);
    }
}
