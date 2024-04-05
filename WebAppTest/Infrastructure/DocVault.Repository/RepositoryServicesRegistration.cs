using DocVault.Application.Contracts.Repository;
using DocVault.Repository.DatabaseContext;
using DocVault.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocVault.Repository
{
    public static class RepositoryServicesRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<LPSDatabaseContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LPSDatabaseConnectionString"));
            });

            // Add specific repositories using AddScoped
            services.AddScoped<IUploadedFileRepository, UploadedFileRepository>();

            return services;
        }
    }
}