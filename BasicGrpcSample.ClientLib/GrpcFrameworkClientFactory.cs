#if NET48
using System;
using ProtoBuf.Grpc.Client;
using Grpc.Core;

namespace BasicGrpcSample.ClientLib
{
    public class GrpcFrameworkClientFactory : IGrpcClientFactory
    {
        private readonly Channel _channel;

        public GrpcFrameworkClientFactory(string grpcServerAddress)
        {
            _channel = new Channel(
                grpcServerAddress,
                ChannelCredentials.Insecure // TODO - make this configurable
                );
        }

        public T GetClient<T>() where T : class
        {
            var svc = _channel.CreateGrpcService<T>();
            return svc;
        }
    }
}
#endif
