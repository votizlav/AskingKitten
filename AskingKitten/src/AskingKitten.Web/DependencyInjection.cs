using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using AskingKitten.Application;

namespace AskingKitten.Web;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddProgramDependencies() =>
            services
                .AddWebDependencies()
                .AddApplication();

        private IServiceCollection AddWebDependencies()
        {
            services.AddControllers();
            services.AddOpenApi();
        
            return services;
        }
    }
}