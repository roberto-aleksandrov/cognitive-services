using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;

namespace CognitiveServices.Application.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(QueryDto queryDto);
    }
}
