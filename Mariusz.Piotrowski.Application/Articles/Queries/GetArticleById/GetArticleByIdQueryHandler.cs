using AutoMapper;
using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using Mariusz.Piotrowski.Application.Common.Exceptions;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDTO>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public GetArticleByIdQueryHandler(IRepository<Article> articleRepository, IMapper mapper) 
        { 
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleDTO> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            
            var existingArticle = await _articleRepository.GetByIdAsync(request.Id);
            if (existingArticle == null)
                throw new NotFoundException(nameof(Article), request.Id);

            return _mapper.Map<ArticleDTO>(existingArticle);
        }
    }
}
