using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.GetArticleStats
{
    public class GetArticleStatsQuery : IRequest<ArticleStatsDTO>
    {
    }
}
