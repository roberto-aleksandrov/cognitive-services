using System;
using System.Net.Http;
using RestClient.Factories.Interfaces;

namespace RestClient.Factories
{
    public class StringContentFactory : IContentFactory
    {
        public HttpContent Create<TContent>(TContent content)
        {
            var stringContent = content as string ?? throw new ArgumentNullException("Content is not a byte array!");

            return new StringContent(stringContent);
        }
    }
}
