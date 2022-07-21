using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
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
            // AddDbContextin ServiceLifetime'ı default olarak scoped'tur. Dependecy inj. yapılan nesne her istediğinde bir tane oluşturur ve onu bize verir. Burada default singleton'a çektik. bir tane oluşturulur ve program çalışırken hep o kullanılır.
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(config.GetConnectionString("ECommerceDB")));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        }
    }
}
