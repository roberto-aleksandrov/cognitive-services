using System;
using System.Net.Http;
using RestClient.Factories.Interfaces;

namespace RestClient.Factories
{
    internal class ByteContentFactory : IContentFactory
    {
        public HttpContent Create<TContent>(TContent content)
        {
            var byteContent = content as byte[] ?? throw new ArgumentNullException("Content is not a byte array!");

            return new ByteArrayContent(byteContent);
        }
    }
}
