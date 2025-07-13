using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
    {
        public DeleteArticleCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Pass correct article guid.");
        }
    }
}
