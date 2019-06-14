using System;
using System.Net.Http;
using RestClient.Factories.Interfaces;

namespace RestClient.Factories
{
    public class ContentFactory : IContentFactory
    {
        public HttpContent Create<TContent>(TContent content)
        {
            if(content is byte[] byteContent)
            {
                return new ByteArrayContent(byteContent);
            }
            if (content is string stringContent)
            {
                return new StringContent(stringContent);
            }

            throw new ArgumentException("Invalid content!");
        }
    }
}
