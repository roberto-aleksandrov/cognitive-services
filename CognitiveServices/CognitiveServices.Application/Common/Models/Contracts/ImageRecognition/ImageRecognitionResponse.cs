using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Models.Contracts.ImageRecognition
{
    public class ImageRecognitionResponse
    {
        public IEnumerable<FaceResponse> Faces { get; set; }

        public IEnumerable<CategoryResponse> Categories { get; set; }

        public IEnumerable<TagResponse> Tags { get; set; }

        public IEnumerable<ObjectResponse> Objects { get; set; }
    }
}
