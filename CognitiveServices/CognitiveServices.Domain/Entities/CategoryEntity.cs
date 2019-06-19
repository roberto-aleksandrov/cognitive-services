using System.Collections.Generic;

namespace CognitiveServices.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity()
        {
            ImageCategories = new List<ImageCategoryEntity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string SingularName { get; set; }

        public int? ParentId { get; set; }

        public CategoryEntity Parent { get; set; }

        public virtual ICollection<ImageCategoryEntity> ImageCategories { get; set; }        
    }
}
