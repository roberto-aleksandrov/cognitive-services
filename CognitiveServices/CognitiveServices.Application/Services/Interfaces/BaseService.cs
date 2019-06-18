using System;
using System.Linq;
using AutoMapper;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected IQueryable<T> ApplyQuery<T>(QueryDto queryDto) where T : BaseEntity
        {
            var queriable = queryDto.Include.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(_context.Set<T>().AsQueryable(),
                                    (current, include) => current.Include(include));

            if (queryDto.Skip != null)
            {
                queriable = queriable.Skip(queryDto.Skip.Value);
            }

            if (queryDto.Take != null)
            {
                queriable = queriable.Take(queryDto.Take.Value);
            }

            return queriable;

        }
    }
}
