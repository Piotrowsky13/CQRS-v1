using AutoMapper;
using Mariusz.Piotrowski.Application.Common.Mappings;
using Mariusz.Piotrowski.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Queries.DTOs
{
    public class ArticleDTO : IMapFrom<Article>
    {
        public string Title { get; set; } = string.Empty!;
        public string Content { get; set; } = string.Empty!;
        public string Author { get; set; } = string.Empty!;
        public string Slug { get; private set; } = string.Empty!;
        public Domain.Enums.Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleDTO>();
        }

    }
}
