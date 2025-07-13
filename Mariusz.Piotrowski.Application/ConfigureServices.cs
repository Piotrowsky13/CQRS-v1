using FluentValidation;
using Mariusz.Piotrowski.Application.Common.Behaviours;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        { 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg => 
            { 
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddLogging();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
