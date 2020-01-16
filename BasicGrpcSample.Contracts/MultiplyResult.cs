using System.Runtime.Serialization;

namespace BasicGrpcSample.Contracts
{
    [DataContract]
    public class MultiplyResult
    {
        [DataMember(Order = 1)]
        public int Result { get; set; }
    }
}
