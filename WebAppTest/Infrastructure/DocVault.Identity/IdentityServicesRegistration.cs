using DocVault.Application.Contracts.Identity;
using DocVault.Application.Models.Identity;
using DocVault.Identity.DatabaseContext;
using DocVault.Identity.Models;
using DocVault.Identity.Services;
using DocVault.Identity.Validator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DocVault.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<LPSDatabaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("LPSDatabaseConnectionString"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
                    opts.Password.RequireNonAlphanumeric = false
                )
                .AddEntityFrameworkStores<LPSDatabaseContext>()
                .AddDefaultTokenProviders()
                .AddPasswordValidator<CustomPasswordValidator<ApplicationUser>>();

            // Add application services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            string jwtSettingKey = configuration["JwtSettings:Key"] ?? "419771ed-7d0a-42b5-8fc5-7196eb9e1917";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingKey))
                }
            );

            return services;
        }
    }
}
