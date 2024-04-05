using DocVault.Application.Contracts.Email;
using DocVault.Application.Contracts.FileHandler;
using DocVault.Application.Models.Email;
using DocVault.Infrastructure.Email;
using DocVault.Infrastructure.FileManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocVault.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Email service register
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IFileHandler, FileHandler>();

            return services;
        }
    }
}
