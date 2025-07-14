using Mariusz.Piotrowski.Domain.Entities;
using Mariusz.Piotrowski.Infrastructure.Presistance.BuilderConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Infrastructure.Presistance
{
    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
