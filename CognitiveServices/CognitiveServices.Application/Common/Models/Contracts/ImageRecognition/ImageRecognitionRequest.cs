using System.Collections.Generic;
using CognitiveServices.Application.Common.Models.Enums;

namespace CognitiveServices.Application.Common.Models.Contracts.ImageRecognition
{
    public class ImageRecognitionRequest
    {
        public IEnumerable<VisualFeatures> VisualFeatures { get; set; } = new List<VisualFeatures>();

        public IEnumerable<Details> Details { get; set; } = new List<Details>();

        public byte[] Image { get; set; }
    }
}
