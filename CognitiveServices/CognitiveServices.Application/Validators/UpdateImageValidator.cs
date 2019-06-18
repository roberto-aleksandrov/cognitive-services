using CognitiveServices.Application.Common.Extensions;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Models.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Validators
{
    public class UpdateImageValidator : AbstractValidator<UpdateImageDto>
    {
        public UpdateImageValidator(ICognitiveServicesDbContext context, IImageRecognitionClient imageRecognitionClient)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Phase 1", () =>
            {
                RuleFor(n => n.Id)
                    .MustAsync(async (id, cancellation) => await context.Images.AnyAsync(n => n.Id == id));
            });

            RuleSet("Phase 2", () =>
            {
                RuleFor(n => n.CategoryIds)
                    .CategoriesAreValid(context, imageRecognitionClient);
            });
        }
    }
}
