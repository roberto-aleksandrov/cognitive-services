namespace RestClient.Builders.Interfaces
{
    using System;
    using System.Net.Http;

    internal interface IHttpRequestMessageBuilder
    {
        IHttpRequestMessageBuilder ToUri(Uri uri);

        IHttpRequestMessageBuilder WithMethod(HttpMethod method);

        IHttpRequestMessageBuilder WithContent(object content);

        IHttpRequestMessageBuilder WithHeaders(Action<HeadersBuilder> headers);

        HttpRequestMessage Build();
    }
}
