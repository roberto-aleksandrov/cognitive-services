namespace RestClient.Client.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using global::RestClient.Builders;

    public interface IRestClient
    {
        Task<TResponse> GetAsync<TResponse>(Uri uri, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : class;

        Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;

        Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;

        Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;
    }
}
