using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;
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
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetAll([FromQuery] QueryDto queryBm)
        {
            var response = await _imagesService.GetAllAsync(queryBm);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDto>> Get([FromRoute] int id)
        {
            var response = await _imagesService.GetByIdAsync(id);

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<ImageDto>> Create([FromForm] UpsertImageBindingModel createImageBm)
        {
            var response = await _imagesService.CreateAsync(Mapper.Map<CreateImageDto>(createImageBm));

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ImageDto>> Update([FromRoute] int? id, [FromForm] UpsertImageBindingModel createImageBm)
        {
            var dto = Mapper.Map<UpdateImageDto>(createImageBm);
            dto.Id = id;

            var response = await _imagesService.UpdateImage(dto);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ImageDto>> Delete([FromRoute] int? id)
        {
            var response = await _imagesService.DeleteAsync(new DeleteImageDto { Id = id });

            return Ok(response);
        }

    }
}
