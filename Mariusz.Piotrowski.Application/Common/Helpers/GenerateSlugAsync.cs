using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Common.Helpers
{
    public static class GenerateSlugHelper
    {
        public async static Task<string> GenerateSlugAsync(this IRepository<Article> repository, string title) 
        {
            var slug = ToSlug(title);

            var similarSlugs = await repository.FindAsync(a => a.Slug == slug || a.Slug.StartsWith(slug + "-"));
            int count = similarSlugs.Count();

            if (count == 0)
                return slug;
            else
                return $"{slug}-{count}";
        }
        private static string ToSlug(string title)
        {
            title = title.ToLowerInvariant().Trim();
            title = Regex.Replace(title, @"\s+", "-");
            title = Regex.Replace(title, @"[^a-z0-9\-]", "");
            title = Regex.Replace(title, @"-+", "-");
            return title.Trim('-');
        }
    }
}
