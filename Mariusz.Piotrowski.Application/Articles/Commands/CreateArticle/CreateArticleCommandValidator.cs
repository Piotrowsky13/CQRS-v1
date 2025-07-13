using FluentValidation;
using Mariusz.Piotrowski.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator :  AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator() 
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title cannot be empty.");

            RuleFor(command => command.Author)
                .NotEmpty().WithMessage("Author can't be empty.");

            RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(10).WithMessage("Content must be at least 10 characters.");
        }
    }
}
