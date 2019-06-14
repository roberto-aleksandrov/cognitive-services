using System.Net.Http;
using System.Net.Http.Headers;
using RestClient.Models.Enumerations;

namespace RestClient.Builders
{
    public class HeadersBuilder
    {
        private readonly HttpRequestHeaders _httpRequestHeaders;
        private readonly HttpContent _httpContent;

        public HeadersBuilder(HttpRequestHeaders httpRequestHeaders, HttpContent httpContent)
        {
            _httpRequestHeaders = httpRequestHeaders;
            _httpContent = httpContent;
        }

        public HeadersBuilder WithAccept(ContentType contentType)
        {
            _httpRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType.Name));
            return this;
        }

        public HeadersBuilder WithContentType(ContentType contentType)
        {
            _httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType.Name);
            return this;
        }

        public HeadersBuilder WithHeader(string key, string value)
        {
            _httpRequestHeaders.Add(key, value);
            return this;
        }

    }
}
