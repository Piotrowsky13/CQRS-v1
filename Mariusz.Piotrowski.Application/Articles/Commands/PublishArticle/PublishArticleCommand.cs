using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.PublishArticle
{
    public class PublishArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public PublishArticleCommand(Guid id) => Id = id;
    }
}
