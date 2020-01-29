using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicGrpcSample.ClientLib;
using BasicGrpcSample.Contracts;
using BasicGrpcSample.Server;
using Grpc.Core;
using ProtoBuf.Grpc.Client;

namespace BasicGrpcSample.FrameworkClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IGrpcClientFactory grpcFactory = new GrpcFrameworkClientFactory("localhost:5001");

            // Contract-First - Greeter
            var client = grpcFactory.GetClient<Greeter.GreeterClient>();
            String user = "Kevin";
            var reply = client.SayHello(new HelloRequest { Name = user });
            Console.WriteLine("Greeting: " + reply.Message);

            // Code-First - Calculator
            var calculator = grpcFactory.GetClient<ICalculator>();
            var result = await calculator.MultiplyAsync(new MultiplyRequest { X = 12, Y = 4 });
            Console.WriteLine(result.Result);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
