using AutoMapper;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty!;
        public string Content { get; set; } = string.Empty!;
        public string Author { get; set; } = string.Empty!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateArticleCommand, Article>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Slug, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());
        }

    }
}
