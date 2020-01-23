namespace BasicGrpcSample.ClientLib
{
    public interface IGrpcClientFactory
    {
        /// <summary>
        /// Gets a Grpc client from the Grpc interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetClient<T>() where T : class;
    }
}
