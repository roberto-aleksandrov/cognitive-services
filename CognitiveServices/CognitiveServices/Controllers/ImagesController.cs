using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Services.Interfaces;
using CognitiveServices.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServices.Controllers
{
    public class ImagesController : BaseController
    {
        private readonly IImagesService _imagesService;

        public ImagesController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetAll()
        {
            var response = await _imagesService.GetAllAsync();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ImageDto>> Create([FromForm] UpsertImageBindingModel createImageBm)
        {
            var response = _imagesService.CreateAsync(Mapper.Map<CreateImageDto>(createImageBm)).Result;

            return Ok(response);
        }

    }
}
