using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Core.Common.Models.Contracts;
using CognitiveServices.Core.Common.Models.Enums;

namespace CognitiveServices.Core.Common.Interfaces.Services
{
    public interface IImageRecognitionClient
    {
        IImageRecognitionClient WithVisualFeatures(IEnumerable<VisualFeatures> visualFeatures);

        IImageRecognitionClient WithDetails(IEnumerable<Details> details);

        Task<ImageRecognitionResponse> Send(ImageRecognitionRequest request);
    }
}
