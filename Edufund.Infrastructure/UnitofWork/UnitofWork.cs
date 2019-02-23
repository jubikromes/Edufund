using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edufund.Data.Context;
using Edufund.Data.Databasefactory;
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
        private readonly IDbContext dbContext;
        public UnitofWork(IContextFactory contextFactory)
        {
            this.dbContext = contextFactory.DbContext;
        }



        public IDbContext Context
        {
            get
            {
                return dbContext;
            }
            set
            {
                value = dbContext;
            }
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> Commit(CancellationToken token)
        {
            // Save changes with the default options
            return await Context.SaveChangesAsync(token);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            this.Dispose(true);

            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(obj: this);
        }
        //properties
        private IMemberRepository memberRepository;
        private IEduFundSystemRepository edufundRepository;


        //public IRepository<TEntity, U> GetRepository<TEntity, U>() where TEntity : BaseEntity<U>
        //{
        //    if (this.repositories == null)
        //    {
        //        this.repositories = new Dictionary<Type, object>();
        //    }
        //    var type = typeof(TEntity);
        //    if (!this.repositories.ContainsKey(type))
        //    {
        //        this.repositories[type] = new EfRepository<TEntity, U>(Context);
        //    }

        //    return (IRepository<TEntity, U>)this.repositories[type];
        //}

        //this seems to work better
        public IMemberRepository MemberRepository
        {
            get
            {

                if (this.memberRepository == null)
                {
                    this.memberRepository = new MemberRepository(dbContext);
                }
                return memberRepository;
            }
        }

        public IEduFundSystemRepository EduFundSystemRepository
        {
            get
            {

                if (this.edufundRepository == null)
                {
                    this.edufundRepository = new EduFundSystemRepository(dbContext);
                }
                return edufundRepository;
            }
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
                    Context = null;
                }
            }
        }
        
        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync(CancellationToken.None);
        }
        public Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
