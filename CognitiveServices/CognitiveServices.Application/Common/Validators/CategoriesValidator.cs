using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Models.Contracts.ImageRecognition;
using CognitiveServices.Application.Common.Models.Enums;
using CognitiveServices.Domain.Entities;
using FluentValidation.Validators;

namespace CognitiveServices.Application.Common.Validators
{
    public class CategoriesValidator : BaseValidator
    {
        private readonly ICognitiveServicesDbContext _cognitiveServicesDbContext;
        private readonly IImageRecognitionClient _imageRecognitionClient;

        public CategoriesValidator(
            ICognitiveServicesDbContext cognitiveServicesDbContext,
            IImageRecognitionClient imageRecognitionClient,
            string errorMessage)
            : base(errorMessage)
        {
            _cognitiveServicesDbContext = cognitiveServicesDbContext;
            _imageRecognitionClient = imageRecognitionClient;
        }

        protected override void PrepareMessageFormatterForValidationError(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("PropertyName", nameof(CreateImageDto.CategoryIds));
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var imageDto = (UpsertImageDto)context.PropertyValue;

            var categoryEntities = _cognitiveServicesDbContext.Categories.Where(n => imageDto.CategoryIds.Contains(n.Id)).ToList();

            var response = await _imageRecognitionClient.SendAsync(new ImageRecognitionRequest
            {
                Image = imageDto.Content,
                VisualFeatures = new List<VisualFeatures> { VisualFeatures.Objects }
            });
            
            return categoryEntities.All(n => response.Objects.Any(m => ValidateCategory(n, m)));
        }

        private bool ValidateCategory(CategoryEntity category, ObjectResponse obj)
        {
            if(obj == null)
            {
                return false;
            }

            return category.SingularName != obj.Object 
                ? ValidateCategory(category, obj.Parent) 
                : true;
        }

    }
}
