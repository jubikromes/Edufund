using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.UnitofWork
{
    public interface IUnitofWork
    {
        Task<int> Commit(CancellationToken token);
        int Commit();
        void Dispose();
        Task<int> SaveChanges();
        Task<int> SaveChanges(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Repository</returns>
        //IRepository<TEntity, U> GetRepository<TEntity, U>()
        //    where TEntity : BaseEntity<U>;

        IMemberRepository MemberRepository { get; }
        IEduFundSystemRepository EduFundSystemRepository { get; }
    }
}
