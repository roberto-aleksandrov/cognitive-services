using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Models.Contracts.ImageRecognition;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Application.Common.Models.Enums;
using CognitiveServices.Domain.Entities;
using FluentValidation.Validators;

namespace CognitiveServices.Application.Common.Validators
{
    public class CategoriesValidator<T> : BaseValidator
        where T : UpsertImageDto
    {
        private readonly ICognitiveServicesDbContext _context;
        private readonly IImageRecognitionClient _imageRecognitionClient;

        public CategoriesValidator(
            ICognitiveServicesDbContext context,
            IImageRecognitionClient imageRecognitionClient,
            string errorMessage)
            : base(errorMessage)
        {
            _context = context;
            _imageRecognitionClient = imageRecognitionClient;
        }

        protected override void PrepareMessageFormatterForValidationError(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("PropertyName", nameof(CreateImageDto.CategoryIds));
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var imageDto = (T)context.Instance;
            var content = await GetContent(imageDto);

            var categoryEntities = _context.Categories.Where(n => imageDto.CategoryIds.Contains(n.Id)).ToList();

            var response = await _imageRecognitionClient.SendAsync(new ImageRecognitionRequest
            {
                Image = content,
                VisualFeatures = new List<VisualFeatures> { VisualFeatures.Objects }
            });
            
            return categoryEntities.All(n => response.Objects.Any(m => ValidateCategory(n, m)));
        }

        private async Task<byte[]> GetContent(T imageDto)
        {
            if(imageDto.Content != null)
            {
                return imageDto.Content;
            }

            var updateImageDto = imageDto as UpdateImageDto ?? throw new ArgumentException("Invalid validation object!");

            var imageEntity = await _context.Images.FindAsync(updateImageDto.Id);

            return imageEntity.Content;
        }

        private bool ValidateCategory(CategoryEntity category, ObjectResponse obj)
        {
            if(obj == null)
            {
                return false;
            }

            return category.SingularName.ToLower() != obj.Object.ToLower() 
                ? ValidateCategory(category, obj.Parent) 
                : true;
        }

    }
}
