using AutoMapper;
using Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle;
using Mariusz.Piotrowski.Application.Common.Mappings;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryCommand, Category>()
                .ConstructUsing(cmd => new Category() { Name = Name });
        }
    }
}
