using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.GetArticleStats
{
    public class GetArticleStatsQueryHandler : IRequestHandler<GetArticleStatsQuery, ArticleStatsDTO>
    {
        private readonly IStatsRepository _statsRepository;
        public GetArticleStatsQueryHandler(IStatsRepository statsRepository) 
        {
            _statsRepository = statsRepository;
        }

        public async Task<ArticleStatsDTO> Handle(GetArticleStatsQuery request, CancellationToken cancellationToken) 
        {
            var allPublished = await _statsRepository.GetAllPublishedArticles();
            var allDrafted = await _statsRepository.GetAllDraftedArticles();
            var mostCategory = await _statsRepository.GetMostUsedCategoryAsync();

            return new ArticleStatsDTO()
            {
                PublishedCount = allPublished,
                DraftCount = allDrafted,
                MostUsedCategory = mostCategory
            };
        }
    }
}
