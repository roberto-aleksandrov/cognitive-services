using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Services
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(
            IValidationService validator,
            ICognitiveServicesDbContext context,
            IMapper mapper) 
            : base(validator, context, mapper)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categoryEntities = await _context.Categories.ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
        }
    }
}
