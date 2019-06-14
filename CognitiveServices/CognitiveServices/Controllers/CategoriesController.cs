using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServices.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var response = await _categoriesService.GetAllAsync();

            return Ok(response);
        }
    }
}
