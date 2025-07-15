using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } = string.Empty!;
        public string Content { get; set; } = string.Empty!;
        public string Author { get; set; } = string.Empty!;
        public string Slug { get; private set; } = string.Empty!;
        public Enums.Status Status { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Article(string title, string content, string author, string slug, Enums.Status status, Guid CategoryId) 
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
            this.Status = status;
            this.Slug = slug;
            this.CategoryId = CategoryId;
        }

        public static string ToSlug(string title) 
        {
            title = title.ToLower().Replace(" ", "-");
            title = Regex.Replace(title, @"[^a-z0-9\-]", "");
            title = Regex.Replace(title, @"-+", "-");
            return title.Trim('-');
        } 
    }
}
