using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Channel channel = new Channel("grpc.jonhussdev.com:80", ChannelCredentials.Insecure);

            //// Contract-First Greeter
            //var client = new Greeter.GreeterClient(channel);
            //String user = "you";
            //var reply = client.SayHello(new HelloRequest { Name = user });
            //Console.WriteLine("Greeting: " + reply.Message);

            // Code-First Calculator
            var calculator = channel.CreateGrpcService<ICalculator>();
            var result = await calculator.MultiplyAsync(new MultiplyRequest { X = 12, Y = 4 });
            Console.WriteLine(result.Result);


            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
