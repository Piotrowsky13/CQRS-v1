using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<ArticleDTO>
    {
        public Guid Id { get; set; }
        public GetArticleByIdQuery(Guid id) => Id = id;
    }
}
