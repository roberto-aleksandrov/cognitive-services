using CognitiveServices.Application.Common.Dtos;

namespace CognitiveServices.Application.Common.Models.Dtos
{
    public class UpdateImageDto : UpsertImageDto
    {
        public int? Id { get; set; }
    }
}
