using System.Net.Http;

namespace RestClient.Serializers.Interfaces
{
    public interface ISerializer
    {
        T Deserialize<T>(string content) where T : class;

        T Serialize<T>(object content) where T : class;
    }
}
