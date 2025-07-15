using FluentValidation;
using Mariusz.Piotrowski.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.PublishArticle
{
    public class PublishArticleCommandValidator : AbstractValidator<PublishArticleCommand>
    {
        public PublishArticleCommandValidator() 
        { 
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
        }
    }
}
