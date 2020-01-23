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
			// Needed for dev env when TLS is not used
			AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

			var serviceCollection = new ServiceCollection();
			//ConfigureServices(serviceCollection);
			serviceCollection.AddLogging(configure => configure.AddConsole());
			var serviceProvider = serviceCollection.BuildServiceProvider();

			// The port number(5001) must match the port of the gRPC server.
			//using var channel = GrpcChannel.ForAddress("http://localhost:5001", new GrpcChannelOptions()
			//{
			//	Credentials = ChannelCredentials.Insecure,
			//	LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>()
			//});

			//using var channel = GrpcChannel.ForAddress("http://52.252.172.110:80", new GrpcChannelOptions()
			//{
			//	Credentials = ChannelCredentials.Insecure,
			//	LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>()
			//});

			using var channel = GrpcChannel.ForAddress("http://grpc.jonhussdev.com", new GrpcChannelOptions()
			{
				Credentials = ChannelCredentials.Insecure,
				LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>()
			});

			// Contract-First - Greeter
			var client = new Server.Greeter.GreeterClient(channel);
			var reply = await client.SayHelloAsync(
							  new Server.HelloRequest { Name = "GreeterClient" });
			Console.WriteLine("Greeting: " + reply.Message);


			// Code-First - Calculator
			//var calculator = channel.CreateGrpcService<ICalculator>();
			//var result = await calculator.MultiplyAsync(new MultiplyRequest { X = 12, Y = 4 });
			//Console.WriteLine(result.Result);

			// Code-First - Order Service
			//var orderSvc = channel.CreateGrpcService<IOrderService>();
			//var result = await orderSvc.GetOrdersAsync(new GetOrdersRequest { OrderIds = new List<string> { "1", "2" } });
			//Console.WriteLine(JsonConvert.SerializeObject(result));

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
