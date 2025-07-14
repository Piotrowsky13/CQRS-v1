using Mariusz.Piotrowski.Application.Articles.Queries.GetAllArticles;
using Mariusz.Piotrowski.Application.Categories.Commands.CreateCategory;
using Mariusz.Piotrowski.Application.Categories.Queries.GetAllCategories;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mariusz.Piotrowski.Api.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoriesQuery());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand request)
        {
            try
            {
                await _mediator.Send(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
