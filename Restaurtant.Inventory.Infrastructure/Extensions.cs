using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Inventory.Application;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.Inventory.Infrastructure.EF.Contexts;
using Restaurant.SharedKernel.Core;
using Restaurtant.Inventory.Infrastructure.EF;
using Restaurtant.Inventory.Infrastructure.EF.Contexts;
using Restaurtant.Inventory.Infrastructure.EF.Repositories;
using Restaurtant.Inventory.Infrastructure.Security;
using System.Reflection;
using System.Text;

namespace Restaurtant.Inventory.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            AddDatabase(services, configuration, isDevelopment);

            AddAuthentication(services, configuration);
            
            return services;
        }


        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("InventoryDbConnectionString");
            services.AddDbContext<ReadDbContext>(context =>
                    context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ITransaccionRepository, TransaccionRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jwtoptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = jwtoptions.ValidateIssuer,
                    ValidateAudience = jwtoptions.ValidateAudience,
                    ValidIssuer = jwtoptions.ValidIssuer,
                    ValidAudience = jwtoptions.ValidAudience
                };
            });
        }
    }
}