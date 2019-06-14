using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;

namespace CognitiveServices.Application.Services.Interfaces
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageDto>> GetAllAsync();

        Task<ImageDto> CreateAsync(CreateImageDto dto);
    }
}
