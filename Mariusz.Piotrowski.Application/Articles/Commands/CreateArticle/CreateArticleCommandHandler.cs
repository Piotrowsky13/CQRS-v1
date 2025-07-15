using AutoMapper;
using Mariusz.Piotrowski.Application.Common.Exceptions;
using Mariusz.Piotrowski.Application.Common.Helpers;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Unit>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<CreateArticleCommandHandler> _logger;

        public CreateArticleCommandHandler(IRepository<Article> articleRepository, ILogger<CreateArticleCommandHandler> logger)
        {
            _articleRepository = articleRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateArticleCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"Error while crating article {request.Title}");
                throw new BadRequestException("Invalid Article request", validationResult);
            }

            var slug = await _articleRepository.GenerateSlugAsync(request.Title);

            var article = new Article(request.Title, request.Content, request.Author, slug, Domain.Enums.Status.Draft, request.CategoryId);

            await _articleRepository.AddAsync(article);

            return Unit.Value;
        }
    }
}
