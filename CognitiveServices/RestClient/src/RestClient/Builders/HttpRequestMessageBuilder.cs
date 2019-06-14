namespace RestClient.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using RestClient.Builders.Interfaces;
    using RestClient.Factories.Interfaces;
    using RestClient.Serializers.Interfaces;

    internal class HttpRequestMessageBuilder : IHttpRequestMessageBuilder
    {
        private readonly ISerializer _serializer;
        private readonly IContentFactory _contentFactory;
        private readonly HttpRequestMessage _requestMessage;
        private ICollection<Action<HeadersBuilder>> _headersActions;

        public HttpRequestMessageBuilder(ISerializer serializer, IContentFactory contentFactory)
        {
            _serializer = serializer;
            _contentFactory = contentFactory;
            _requestMessage = new HttpRequestMessage();
            _headersActions = new List<Action<HeadersBuilder>>();
        }

        public HttpRequestMessage Build()
        {
            foreach (var headersAction in _headersActions)
            {
                headersAction.Invoke(new HeadersBuilder(_requestMessage.Headers, _requestMessage.Content));
            }
            
            return _requestMessage;
        }

        public IHttpRequestMessageBuilder ToUri(Uri uri)
        {
            _requestMessage.RequestUri = uri ?? throw new ArgumentException("Uri cannot be null.");
            return this;
        }

        public IHttpRequestMessageBuilder WithContent(object content)
        {
            if (content != null)
            {
                _requestMessage.Content = _contentFactory.Create(_serializer.Serialize<object>(content));
            }

            return this;
        }

        public IHttpRequestMessageBuilder WithHeaders(Action<HeadersBuilder> action)
        {
            if(action != null)
            {
                _headersActions.Add(action);
            }

            return this;
        }

        public IHttpRequestMessageBuilder WithMethod(HttpMethod method)
        {
            _requestMessage.Method = method ?? HttpMethod.Get;
            return this;
        }
    }
}
