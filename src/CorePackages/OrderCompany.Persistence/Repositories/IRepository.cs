using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using OrderCompany.Persistence.Entities;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Persistence.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : Entity
    {
        T Get(Expression<Func<T, bool>> predicate);

        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0, int size = 10,
            bool enableTracking = true);


        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
