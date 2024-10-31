using Microsoft.Extensions.DependencyInjection;
using Repository.Entity;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ExtensionIserviceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<DeceasdDetails>,DeceasdRepository> ();
            services.AddScoped<ILogin, UserRepository>();
            services.AddScoped<IRepository<ResponseDetails>, ResponseRepository>();
            services.AddScoped<IRepository<StoryDetailes>, StoryRepository>();
            return services;
        }
    }
}
