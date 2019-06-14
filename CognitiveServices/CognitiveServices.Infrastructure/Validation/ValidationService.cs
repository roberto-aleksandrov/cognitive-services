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

            var failures = (await validator
                    .ValidateAsync(model))
                    .Errors
                    .ToList();

            if (failures.Count != 0)
            {
                throw new Application.Common.Exceptions.ValidationException(ErrorTypes.InvalidData, failures);
            }
        }
    }
}
