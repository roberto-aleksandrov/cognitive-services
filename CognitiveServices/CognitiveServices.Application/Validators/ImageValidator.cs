using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Extensions;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using FluentValidation;

namespace CognitiveServices.Application.Validators
{
    public class ImageValidator : AbstractValidator<UpsertImageDto>
    {
        public ImageValidator(ICognitiveServicesDbContext context, IImageRecognitionClient imageRecognitionClient)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Content)
                .NotEmpty();

            RuleFor(n => n.CategoryIds)
                .NotEmpty();

            RuleFor(n => n)
                .CategoriesAreValid(context, imageRecognitionClient);
        }
    }
}
