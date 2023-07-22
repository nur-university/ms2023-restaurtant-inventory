using Microsoft.Extensions.DependencyInjection;
using Restaurant.Inventory.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application
{
    public static class Extensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IItemFactory, ItemFactory>();
            services.AddSingleton<ITransaccionFactory, TransaccionFactory>();

            return services;
        }
    }
}
