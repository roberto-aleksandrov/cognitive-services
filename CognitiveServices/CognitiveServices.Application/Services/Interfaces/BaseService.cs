using AutoMapper;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;

namespace CognitiveServices.Application.Services.Interfaces
{
    public class BaseService
    {
        protected readonly IValidationService _validator;
        protected readonly ICognitiveServicesDbContext _context;
        protected readonly IMapper _mapper;

        public BaseService(
            IValidationService validator,
            ICognitiveServicesDbContext context,
            IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }
    }
}
