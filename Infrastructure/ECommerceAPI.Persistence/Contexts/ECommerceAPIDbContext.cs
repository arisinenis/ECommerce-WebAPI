using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        // Repository de bunu kullandığımız için, bu SaveChangesAsync'i override edeceğiz.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker : Entityler üzerinden yapılan değişikliklerin yada yeni eklenen verirnin yakalanmasını sağlayan property. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            // Entries : Gelen girdileri yakalamamızı sağlar. (Insert, update işlemlerindeki)
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
