using System.Linq;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Constants.Validators;
using CognitiveServices.Application.Common.Interfaces.Validation;
using FluentValidation;

namespace CognitiveServices.Infrastructure.Validation
{
    public class ValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidationService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public async Task ValidateAsync<T>(T model)
        {
            var validator = _validatorFactory.GetValidator<T>();

            await InvokePhases(validator, model, "Phase 1");
            await InvokePhases(validator, model, "Phase 2");
        }

        private async Task InvokePhases<T>(IValidator<T> validator, T model, string phases)
        {
            var failures = (await validator
                       .ValidateAsync(model, ruleSet: phases))
                       .Errors
                       .ToList();

            if (failures.Count != 0)
            {
                throw new Application.Common.Exceptions.ValidationException(ErrorTypes.InvalidData, failures);
            }
        }
    }
}
