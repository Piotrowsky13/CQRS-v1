using AutoMapper;
using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using Mariusz.Piotrowski.Application.Articles.Queries.GetAllArticles;
using Mariusz.Piotrowski.Application.Categories.Queries.DTOs;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryDTO>>(categories);
        }
    }
}
