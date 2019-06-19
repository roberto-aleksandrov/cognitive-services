using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> ImageIds { get; set; }

        public int? ParentId { get; set; }

        public CategoryDto Parent { get; set; }
    }
}
