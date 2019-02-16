using Edufund.Data.Entities;
using Edufund.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Repositories.Abstractions
{
    public interface IAsyncRepository<T, U> where T : BaseEntity<U>
    {
        Task<T> GetByIdAsync(U id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);

        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
