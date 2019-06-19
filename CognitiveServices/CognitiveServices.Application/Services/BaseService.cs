using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using AutoMapper;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Domain.Entities;
using Extensions;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Services
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
            var queriable = queryDto.Include
                            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Aggregate(_context.Set<T>().AsQueryable(),
                                    (current, include) => current.Include(include));

            queryDto.Where?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ForEach(n =>
            {
                queriable = queriable.Where(n);
            });

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
