using BasicGrpcSample.Contracts;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;

namespace BasicGrpcSample.ConsoleClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// The port number(5001) must match the port of the gRPC server.
			using var channel = GrpcChannel.ForAddress("http://grpc.jonhussdev.com", new GrpcChannelOptions() 
			{
				Credentials = ChannelCredentials.Insecure
			});

			//// Contract-First Greeter
			//var client = new Server.Greeter.GreeterClient(channel);
			//var reply = await client.SayHelloAsync(
			//				  new Server.HelloRequest { Name = "GreeterClient" });
			//Console.WriteLine("Greeting: " + reply.Message);
			

			// Code-First Calculator
			var calculator = channel.CreateGrpcService<ICalculator>();
			var result = await calculator.MultiplyAsync(new MultiplyRequest { X = 12, Y = 4 });
			Console.WriteLine(result.Result);

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
