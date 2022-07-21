using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T>
        where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table 
            => _context.Set<T>(); // Bize table'ı döndürüyor.

        // Sadece okuma işlemi yaptığımız için, yani db'deki verileri çekip listelediğimiz için track edilmesine gerek yok. Bu yüzden optimizasyon işlemi yaptık. Yani track mekanizmasını devre dışı bıraktık.

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable(); // AsQueryable() metodu ile IQueryable tipine dönüştürdük.

            if (!tracking)
            {
                query = query.AsNoTracking(); // query ile gelecek olan dataların ef tarafından track edilmesini kestik.
            }

            return query;
        } 


        //IQueryable sadece verilen şartı sağlayan dataları veritabanından çeker. Tüm dataları çektikten sonra şartı uygulamaz ! Performans açısından önemli
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(expression);
        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
