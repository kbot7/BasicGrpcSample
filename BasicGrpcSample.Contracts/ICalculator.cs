using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BasicGrpcSample.Contracts
{
    [ServiceContract(Name = "Hyper.Calculator")]
    public interface ICalculator
    {
        Task<MultiplyResult> MultiplyAsync(MultiplyRequest request);
    }
}
