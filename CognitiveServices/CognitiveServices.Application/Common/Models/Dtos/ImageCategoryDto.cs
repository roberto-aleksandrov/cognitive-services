using CognitiveServices.Application.Common.Dtos;

namespace CognitiveServices.Application.Common.Models.Dtos
{
    public class ImageCategoryDto
    {
        public int ImageId { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}
