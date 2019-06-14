using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CognitiveServices.Models.BindingModels
{
    public class UpsertImageBindingModel
    {
        public IFormFile Content { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }
}
