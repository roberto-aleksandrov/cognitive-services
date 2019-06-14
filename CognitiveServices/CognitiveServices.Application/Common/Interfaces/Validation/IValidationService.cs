using System.Threading.Tasks;

namespace CognitiveServices.Application.Common.Interfaces.Validation
{
    public interface IValidationService
    {
        Task ValidateAsync<T>(T model);
    }
}
