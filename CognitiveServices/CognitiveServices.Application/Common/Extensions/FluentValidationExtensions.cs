using CognitiveServices.Application.Common.Constants.Validators;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Validators;
using FluentValidation;

namespace CognitiveServices.Application.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TModel, TModel> CategoriesAreValid<TModel>(
            this IRuleBuilder<TModel, TModel> ruleBuilder,
            ICognitiveServicesDbContext cognitiveServicesDbContext,
            IImageRecognitionClient imageRecognitionClient,
            string errorMessage = ErrorMessages.InvalidProperty)
        {
            return ruleBuilder.SetValidator(new CategoriesValidator(cognitiveServicesDbContext, imageRecognitionClient, errorMessage));
        }
    }
}
