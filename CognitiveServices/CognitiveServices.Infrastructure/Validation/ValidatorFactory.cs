using System;
using FluentValidation;

namespace CognitiveServices.Infrastructure.Validation
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)_serviceProvider.GetService(typeof(IValidator<T>));
        }

        public IValidator GetValidator(Type type)
        {
            return (IValidator) _serviceProvider.GetService(type);
        }
    }
}
