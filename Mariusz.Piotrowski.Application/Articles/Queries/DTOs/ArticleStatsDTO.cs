using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.DTOs
{
    public class ArticleStatsDTO : IRequest<Unit>
    {
        public int PublishedCount { get; set; }
        public int DraftCount { get; set; }
        public string? MostUsedCategory { get; set; }
    }
}
