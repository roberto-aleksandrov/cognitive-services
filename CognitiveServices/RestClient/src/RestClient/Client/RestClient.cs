namespace RestClient.Client
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Interfaces;
    using Client.Interfaces;
    using Contracts.Interfaces;
    using Exceptions;
    using global::RestClient.Builders;
    using Serializers.Interfaces;

    internal class RestClient : IRestClient
    {
        private readonly HttpClient _client;
        private readonly IHttpRequestBuilder _httpRequestBuilder;
        private readonly ISerializer _serializer;
        private readonly IExecutor<HttpRequestMessage, HttpResponseMessage> _executor;
        private readonly Action<HeadersBuilder> _defaultHeaders;

        public RestClient(
            HttpClient client,
            IHttpRequestBuilder httpRequestBuilder,
            ISerializer serializer,
            IExecutor<HttpRequestMessage, HttpResponseMessage> executor,
            Action<HeadersBuilder> defaultHeaders)
        {
            _client = client;
            _httpRequestBuilder = httpRequestBuilder;
            _serializer = serializer;
            _executor = executor;
            _defaultHeaders = defaultHeaders;
        }

        private HttpRequestMessage BuildRequestMessage(HttpMethod method, Uri uri, Action<HeadersBuilder> headers, object request = null)
        {
            return _httpRequestBuilder.New()
                .ToUri(uri)
                .WithContent(request)
                .WithHeaders(_defaultHeaders)
                .WithHeaders(headers)
                .WithMethod(method)
                .Build();
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
            where TResponse : class
        {
            var context = new Contracts.ExecutionContext(requestMessage);
            var response = await _executor.ExecuteAsync(async () => await _client.SendAsync(requestMessage, cancellationToken), context);

            if (!response.IsSuccessStatusCode)
            {
                throw new RestClientException(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
            }

            return _serializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default)
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Get, uri, headers);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Post, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Put, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, Action<HeadersBuilder> headers = null, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Delete, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }
    }
}
