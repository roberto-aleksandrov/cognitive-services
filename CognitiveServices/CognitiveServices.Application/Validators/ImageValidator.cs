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

            RuleSet("Phase 1", () =>
            {
                RuleFor(n => n.CategoryIds)
                    .NotEmpty();

                RuleFor(n => n.Content)
                    .NotEmpty();
            });

            RuleSet("Phase 2", () =>
            {
                RuleFor(n => n)
                    .CategoriesAreValid(context, imageRecognitionClient);

            });
        }
    }
}
