﻿using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    // Queryler için kullanılacak. -GetAll gibi (Data manipulation için değil yalnızca datayı okumak için kullanılanlar)
    public interface IReadRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id, bool tracking = true);
        IQueryable <T> GetAll(bool tracking = true);
        IQueryable <T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);
    }
}
