using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Models.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Validators
{
    public class DeleteImageValidator : AbstractValidator<DeleteImageDto>
    {
        public DeleteImageValidator(ICognitiveServicesDbContext context)
        {
            RuleSet("Phase 1", () =>
            {
                RuleFor(n => n.Id)
               .NotEmpty()
               .MustAsync(async (id, cancellation) => await context.Images.AnyAsync(n => n.Id == id.Value));
            });
        }
    }
}
