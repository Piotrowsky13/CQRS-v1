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

namespace Mariusz.Piotrowski.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<DeleteArticleCommandHandler> _logger;

        public DeleteArticleCommandHandler(IRepository<Article> articleRepository, ILogger<DeleteArticleCommandHandler> logger) 
        {
            _articleRepository = articleRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken) 
        {
            var validator = new DeleteArticleCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"Error while deleting article with id={request.Id}");
                throw new BadRequestException("Invalid delete Article request", validationResult);
            }

            var existingArticle = await _articleRepository.GetByIdAsync(request.Id);
            if (existingArticle == null)
                throw new NotFoundException(nameof(Article), request.Id);

            _articleRepository.DeleteById(existingArticle);

            return Unit.Value;
        }
    }
}
