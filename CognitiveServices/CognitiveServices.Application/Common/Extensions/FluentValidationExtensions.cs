using CognitiveServices.Application.Common.Constants.Validators;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Validators;
using FluentValidation;

namespace CognitiveServices.Application.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TModel, TProperty> CategoriesAreValid<TModel, TProperty>(
            this IRuleBuilder<TModel, TProperty> ruleBuilder,
            ICognitiveServicesDbContext cognitiveServicesDbContext,
            IImageRecognitionClient imageRecognitionClient,
            string errorMessage = ErrorMessages.InvalidCategories)
            where TModel : UpsertImageDto
        {
            return ruleBuilder.SetValidator(new CategoriesValidator<TModel>(cognitiveServicesDbContext, imageRecognitionClient, errorMessage));
        }
    }
}
