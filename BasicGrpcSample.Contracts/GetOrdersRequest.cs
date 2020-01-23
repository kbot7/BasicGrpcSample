using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class GetOrdersRequest
    {
        [DataMember(Order = 1)]
        public List<string> OrderIds { get; set; } = new List<string>();
    }
}
