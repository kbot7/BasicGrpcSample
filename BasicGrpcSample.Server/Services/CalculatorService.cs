using BasicGrpcSample.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace BasicGrpcSample.Server.Services
{
    public class CalculatorService : ICalculator
    {
        Task<MultiplyResult> ICalculator.MultiplyAsync(MultiplyRequest request)
        {
            var result = new MultiplyResult { Result = request.X * request.Y };
            return Task.FromResult(result);
        }
    }
}
