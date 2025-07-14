using FluentValidation;
using Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle;
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

namespace Mariusz.Piotrowski.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILogger<CreateArticleCommandHandler> _logger;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository, ILogger<CreateArticleCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"Error while crating category {request.Name}");
                throw new BadRequestException("Invalid Category request", validationResult);
            }

            var category = new Category { Name = request.Name };

            await _categoryRepository.AddAsync(category);

            return Unit.Value;
        }
    }
}
