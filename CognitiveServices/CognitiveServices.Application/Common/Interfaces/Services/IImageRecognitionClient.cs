using System.Threading.Tasks;
using CognitiveServices.Application.Common.Models.Contracts.ImageRecognition;

namespace CognitiveServices.Application.Common.Interfaces.Services
{
    public interface IImageRecognitionClient
    {
        Task<ImageRecognitionResponse> SendAsync(ImageRecognitionRequest request);
    }
}
