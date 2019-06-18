using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Models.Validation
{
    public class ImageCategoryValidationModel
    {
        public int? Id { get; set; }

        public byte[] Content { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }
}
