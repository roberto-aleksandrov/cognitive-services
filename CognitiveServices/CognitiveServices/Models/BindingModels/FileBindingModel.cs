using Microsoft.AspNetCore.Http;

namespace CognitiveServices.Models.BindingModels
{
    public class FileBindingModel
    {
        public IFormFile File { get; set; }
    }
}
