using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edufund.Data.Context;
using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using Edufund.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore.Storage;

namespace Edufund.Infrastructure.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {


        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> repositories;
        private IDbContextTransaction dbContextTransaction;
        private IDbContext dbContext;


        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> Commit(CancellationToken token)
        {
            // Save changes with the default options
            return await this.dbContext.SaveChangesAsync(token);
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }
        public void Dispose()
        {
            this.Dispose(true);

            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(obj: this);
        }
        public IRepository<TEntity, U> GetRepository<TEntity, U>() where TEntity : BaseEntity<U>
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new EfRepository<TEntity, U>(this.dbContext);
            }

            return (IRepository<TEntity, U>)this.repositories[type];
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                    this.dbContext = null;
                }
            }
        }
        
        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
