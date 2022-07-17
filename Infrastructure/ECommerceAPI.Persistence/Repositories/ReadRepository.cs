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

        public IQueryable<T> GetAll() 
            => Table;

        //IQueryable sadece verilen şartı sağlayan dataları veritabanından çeker. Tüm dataları çektikten sonra şartı uygulamaz ! Performans açısından önemli
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) 
            => Table.Where(expression);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
            => await Table.FirstOrDefaultAsync(expression);

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
