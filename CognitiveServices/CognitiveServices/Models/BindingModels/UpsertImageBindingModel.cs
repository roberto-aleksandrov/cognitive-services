using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace CognitiveServices.Models.BindingModels
{
    public class UpsertImageBindingModel
    {
        public IFormFile Content { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }
}
