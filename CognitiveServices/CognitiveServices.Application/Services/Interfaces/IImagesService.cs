using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;

namespace CognitiveServices.Application.Services.Interfaces
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageDto>> GetAllAsync(QueryDto dto);

        Task<ImageDto> CreateAsync(CreateImageDto dto);

        Task<ImageDto> UpdateImage(UpdateImageDto dto);

        Task<ImageDto> DeleteAsync(DeleteImageDto imageDto);

        Task<ImageDto> GetByIdAsync(int id);
    }
}
