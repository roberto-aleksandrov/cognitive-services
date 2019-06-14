using System.Net.Http;

namespace RestClient.Factories.Interfaces
{
    internal interface IContentFactory
    {
        HttpContent Create<TContent>(TContent content);
    }
}
