using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class Order
    {
        [DataMember(Order = 1)]
        public string OrderId { get; set; }
        [DataMember(Order = 2)]
        public Customer Customer { get; set; }
        [DataMember(Order = 3)]
        public DateTime DateTimePlaced { get; set; }
        [DataMember(Order = 4)]
        public List<string> Skus { get; set; } = new List<string>();
    }
}
