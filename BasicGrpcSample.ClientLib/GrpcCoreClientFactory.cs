#if NETSTANDARD2_1
using System;
using ProtoBuf.Grpc.Client;
using Grpc.Net.Client;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace BasicGrpcSample.ClientLib
{
    public class GrpcCoreClientFactory : IGrpcClientFactory, IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly GrpcChannel _channel;

        public GrpcCoreClientFactory(string grpcServerAddress,
            ILoggerFactory loggerFactory = null
            )
        {
            _loggerFactory = loggerFactory;
            
            var opt = new GrpcChannelOptions()
            {
                // TODO - Need a way to flip this via a flag
                Credentials = ChannelCredentials.Insecure,
                LoggerFactory = _loggerFactory
            };

            _channel = GrpcChannel.ForAddress(grpcServerAddress, opt);
        }

        public void Dispose()
        {
            _channel.Dispose();
        }

        public T GetClient<T>() where T : class
        {
            var svc = _channel.CreateGrpcService<T>();
            return svc;
        }
    }
}
#endif
