
using System.Threading;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.UnitofWork
{
    public interface IUnitofWork
    {
        void BeginTransaction();
        Task<int> Commit();
        void Dispose(bool disposing);
        void Rollback();
        Task<int> SaveChanges();
        Task<int> SaveChanges(CancellationToken cancellationToken);
        void Save();
    }
}
