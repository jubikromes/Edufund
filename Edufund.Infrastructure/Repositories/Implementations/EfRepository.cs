using Edufund.Data.Context;
using Edufund.Data.Databasefactory;
using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using Edufund.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Repositories.Implementations
{
    public class EfRepository<T, U> : IRepository<T, U>, IAsyncRepository<T, U> where T : BaseEntity<U>
    {
        protected readonly IDbContext _dbContext;
        private readonly DbSet<T> dbSet;

        public EfRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        //public EfRepository(EduFundContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public virtual T GetById(U id)
        {
            return dbSet.Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(U id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public IEnumerable<T> ListAll()
        {
            return this.dbSet.AsEnumerable();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            return ApplySpecification(spec).AsEnumerable();
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public int Count(ISpecification<T> spec)
        {
            return ApplySpecification(spec).Count();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public T Add(T entity)
        {
            this.dbSet.Add(entity);

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
           var addEntity = await this.dbSet.AddAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                this.dbSet.Update(entity);
                //_dbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(exception.ToString());
            }
           // _dbContext.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T, U>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
        public IQueryable<T> FromSql(string query, params object[] parameters)
        {
            return this.dbSet.FromSql(query, parameters);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include, string include2)
        {
            return this.dbSet.Include(include).Include(include2);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation)
        {
           return await _dbContext.SaveChangesAsync(cancellation);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
