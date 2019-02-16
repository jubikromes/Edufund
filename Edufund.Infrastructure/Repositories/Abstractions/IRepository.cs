using Edufund.Data.Entities;
using Edufund.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Repositories.Abstractions
{
    public interface IRepository<T, U> where T : BaseEntity<U>
    {
        T GetById(U id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(ISpecification<T> spec);

        IQueryable<T> FromSql(string sql, params object[] parameters);
        IQueryable<T> GetAll(string include, string include2);

        int SaveChanges();

    }
}
