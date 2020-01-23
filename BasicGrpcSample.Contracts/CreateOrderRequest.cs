using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class CreateOrderRequest
    {
        [DataMember(Order = 1)]
        public string CustomerId { get; set; }
        [DataMember(Order = 2)]
        public DateTime DateTimePlaced { get; set; }
        [DataMember(Order = 3)]
        public List<string> Skus { get; set; } = new List<string>();
    }
}
