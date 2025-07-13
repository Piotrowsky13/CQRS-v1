using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using Mariusz.Piotrowski.Infrastructure.Presistance;
using Mariusz.Piotrowski.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mariusz.Piotrowski.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<Context>(options => 
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection") ?? 
                        throw new InvalidOperationException("Invalid connection string..."))
                );

            services.AddScoped<IRepository<Article>, ArticleRepository>();
            return services;
        }
    }
}
