using System.Collections.Generic;
using CognitiveServices.Application.Common.Models.Dtos;

namespace CognitiveServices.Application.Common.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] Content { get; set; }

        public IEnumerable<ImageCategoryDto> ImageCategories { get; set; }
    }
}
