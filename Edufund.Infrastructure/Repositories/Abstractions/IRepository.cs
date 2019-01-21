using Edufund.Data.Entities;
using Edufund.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
