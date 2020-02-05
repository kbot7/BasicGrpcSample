using System.Collections.Generic;
using System.ServiceModel;

namespace BasicGrpcSample.Contracts
{
    [ServiceContract(Name = "SyncOrderService")]
    public interface ISyncOrderService
    {
        Order GetOrder(GetOrderRequest request);
        Order CreateOrder(CreateOrderRequest request);
        List<Order> GetOrders(GetOrdersRequest request);
    }
}
