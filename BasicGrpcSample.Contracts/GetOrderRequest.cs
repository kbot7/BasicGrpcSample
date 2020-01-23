using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class GetOrderRequest
    {
        [DataMember(Order = 1)]
        public string OrderId { get; set; }
    }
}
