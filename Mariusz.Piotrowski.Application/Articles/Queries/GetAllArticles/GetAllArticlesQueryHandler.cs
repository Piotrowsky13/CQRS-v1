
using AutoMapper;
using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.GetAllArticles
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleDTO>>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public GetAllArticlesQueryHandler(IRepository<Article> articleRepository, IMapper mapper) 
        { 
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<List<ArticleDTO>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken) 
        {
            var articles = await _articleRepository.GetAllAsync();

            return _mapper.Map<List<ArticleDTO>>(articles);
        }
    }
}
