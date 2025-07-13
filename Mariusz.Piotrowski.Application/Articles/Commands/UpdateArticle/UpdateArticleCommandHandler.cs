using AutoMapper;
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

namespace Mariusz.Piotrowski.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<UpdateArticleCommandHandler> _logger;
        public UpdateArticleCommandHandler(IRepository<Article> articleRepository, ILogger<UpdateArticleCommandHandler> logger) 
        { 
            _articleRepository = articleRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateArticleCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any()) 
            {
                _logger.LogWarning($"Error while updating article {request.Title} with id={request.Id}");
                throw new BadRequestException("Invalid update Article requst", validationResult);
            }

            var existingArticle = await _articleRepository.GetByIdAsync(request.Id);

            if (existingArticle == null)
                throw new NotFoundException(nameof(Article), request.Id);

            existingArticle.Title = request.Title ?? existingArticle.Title;
            existingArticle.Content = request.Content ?? existingArticle.Content;
            existingArticle.Author = request.Author ?? existingArticle.Author;

            _articleRepository.Update(existingArticle);

            return Unit.Value;
        }
    }
}
