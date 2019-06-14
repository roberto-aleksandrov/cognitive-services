using System.Collections.Generic;

namespace CognitiveServices.Domain.Entities
{
    public class ImageEntity : BaseEntity
    {
        public ImageEntity()
        {
            ImageCategories = new List<ImageCategoryEntity>();
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        public virtual ICollection<ImageCategoryEntity> ImageCategories { get; set; }
    }
}
