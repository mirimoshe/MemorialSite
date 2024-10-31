using Common.Entity;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped < IService < DeceasdDetailesDto >, DeceasdService > ();
            services.AddScoped<ILoginService, UserService >();
            services.AddScoped<IService<ResponseDetailsDto>,ResponseService>();
            services.AddScoped<IService<StoryDetailesDto>, StoryService>();
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}



