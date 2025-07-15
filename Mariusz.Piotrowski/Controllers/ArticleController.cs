using Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle;
using Mariusz.Piotrowski.Application.Articles.Commands.DeleteArticle;
using Mariusz.Piotrowski.Application.Articles.Commands.PublishArticle;
using Mariusz.Piotrowski.Application.Articles.Commands.UpdateArticle;
using Mariusz.Piotrowski.Application.Articles.Queries.GetAllArticles;
using Mariusz.Piotrowski.Application.Articles.Queries.GetArticleById;
using Mariusz.Piotrowski.Application.Articles.Queries.GetArticleStats;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace Mariusz.Piotrowski.Api.Controllers
{
    [ApiController]
    [Route("/api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand request)
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

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                var result = await _mediator.Send(new GetAllArticlesQuery());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetArtivleById(Guid id)
        {
            try
            {
                var article = await _mediator.Send(new GetArticleByIdQuery(id));
                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateArticle(Guid id, [FromBody] UpdateArticleCommand request)
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

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteArticle(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteArticleCommand(id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id:Guid}/publish")]
        public async Task<IActionResult> PublishArticle(Guid id)
        {
            try
            {
               await _mediator.Send(new PublishArticleCommand(id));
               return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetAtriclesStats()
        {
            var articleStats = await _mediator.Send(new GetArticleStatsQuery());
            return Ok(articleStats);
        }
    }
}
