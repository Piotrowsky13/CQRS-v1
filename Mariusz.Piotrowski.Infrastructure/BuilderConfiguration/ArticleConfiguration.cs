using Mariusz.Piotrowski.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mariusz.Piotrowski.Infrastructure.BuilderConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            builder.Property(x => x.Id).HasColumnType("Guid");
        }
    }
}
