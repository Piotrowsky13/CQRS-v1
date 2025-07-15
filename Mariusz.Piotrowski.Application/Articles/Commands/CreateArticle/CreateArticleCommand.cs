using AutoMapper;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty!;
        public string Content { get; set; } = string.Empty!;
        public string Author { get; set; } = string.Empty!;
        public Guid CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArticleCommand, Article>()
                .ConstructUsing(cmd => new Article(cmd.Title, cmd.Content, cmd.Author, "",Domain.Enums.Status.Draft, cmd.CategoryId))
                .ForMember(dest => dest.Slug, opt => opt.Ignore()); ;
        }
    }
}
