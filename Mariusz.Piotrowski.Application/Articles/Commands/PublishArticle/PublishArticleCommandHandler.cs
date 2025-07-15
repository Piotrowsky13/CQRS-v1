using FluentValidation;
using Mariusz.Piotrowski.Application.Common.Exceptions;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.PublishArticle
{
    public class PublishArticleCommandHandler : IRequestHandler<PublishArticleCommand, Unit>
    {

        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<PublishArticleCommandHandler> _logger;

        public PublishArticleCommandHandler(IRepository<Article> articleRepository, ILogger<PublishArticleCommandHandler> logger)
        {
            _articleRepository = articleRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(PublishArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new PublishArticleCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation failed for article {Id}: {Errors}", request.Id, 
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));

                throw new BadRequestException(nameof(request), validationResult);
            }

            var article = await _articleRepository.GetByIdAsync(request.Id);
            if (article == null)
            {
                throw new NotFoundException(nameof(request), request.Id);
            }

            article.Status = Domain.Enums.Status.Published;

            _articleRepository.Update(article);

            return Unit.Value;
        }
    }
}
