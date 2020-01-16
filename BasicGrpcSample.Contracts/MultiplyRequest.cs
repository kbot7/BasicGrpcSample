using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class MultiplyRequest
    {
        [DataMember(Order = 1)]
        public int X { get; set; }

        [DataMember(Order = 2)]
        public int Y { get; set; }
    }
}
