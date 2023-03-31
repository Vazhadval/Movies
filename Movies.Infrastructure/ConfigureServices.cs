using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Common.Interfaces;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddHttpClient<IImdbService, ImdbService>(Options =>
            {
                Options.BaseAddress = new Uri(configuration["ImdbApiSettings:BaseUrl"]);
            });

            return services;
        }
    }
}
