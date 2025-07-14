using AutoMapper;
using Mariusz.Piotrowski.Application.Articles.Queries.DTOs;
using Mariusz.Piotrowski.Application.Common.Mappings;
using Mariusz.Piotrowski.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Categories.Queries.DTOs
{
    public class CategoryDTO : IMapFrom<Category>
    {
        public string Name { get; set; } = string.Empty!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDTO>();
        }
    }
}
