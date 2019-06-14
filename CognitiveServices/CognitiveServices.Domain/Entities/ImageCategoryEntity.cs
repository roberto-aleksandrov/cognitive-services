namespace CognitiveServices.Domain.Entities
{
    public class ImageCategoryEntity : BaseEntity
    {
        public int ImageId { get; set; }

        public ImageEntity Image { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity Category{ get; set; }
    }
}
