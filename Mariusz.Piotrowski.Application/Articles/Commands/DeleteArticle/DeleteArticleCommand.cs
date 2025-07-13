using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DeleteArticleCommand(Guid id) => Id = id;
    }
}
