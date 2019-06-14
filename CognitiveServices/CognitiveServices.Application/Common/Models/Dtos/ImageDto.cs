using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
