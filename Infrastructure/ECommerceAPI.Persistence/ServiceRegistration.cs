using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(config.GetConnectionString("ECommerceDB")));
        }
    }
}
