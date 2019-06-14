using Newtonsoft.Json;
using RestClient.Serializers.Interfaces;

namespace CognitiveServices.Infrastructure.ImageRecognition
{
    internal class Serializer : ISerializer
    {
        public T Deserialize<T>(string content)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public T Serialize<T>(object content)
            where T : class
        {
            return (T)content;
        }
    }
}
