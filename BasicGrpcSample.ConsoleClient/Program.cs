using BasicGrpcSample.ClientLib;
using BasicGrpcSample.Contracts;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicGrpcSample.ConsoleClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Required for local development with TLS disabled
			AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

			IGrpcClientFactory grpcFactory = new GrpcCoreClientFactory("http://localhost:5001");
			//IGrpcClientFactory grpcFactory = new GrpcCoreClientFactory("http://grpc.jonhussdev.com");

			// Contract-First - Greeter
			//var greeter = grpcFactory.GetClient<Server.Greeter.GreeterClient>();
			//var reply = await greeter.SayHelloAsync(
			//				  new Server.HelloRequest { Name = "GreeterClient" });
			//Console.WriteLine("Greeting: " + reply.Message);


			// Code-First - Calculator
			//var calculator = grpcFactory.GetClient<ICalculator>();
			//var result = await calculator.MultiplyAsync(new MultiplyRequest { X = 12, Y = 4 });
			//Console.WriteLine(result.Result);

			// Code-First - Order Service
			var orderSvc = grpcFactory.GetClient<IOrderService>();
			var result = await orderSvc.CreateOrderAsync(new CreateOrderRequest() 
			{ 
				Customer = new Customer 
				{
					FirstName = "John",
					LastName = "Doe",
					DateOfBirth = DateTime.UtcNow
				}, 
				DateTimePlaced = DateTime.UtcNow, 
				Skus = new List<string> { "a", "b" } 
			});
			Console.WriteLine(JsonConvert.SerializeObject(result));

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
