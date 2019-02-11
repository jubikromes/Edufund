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
        public EfRepository(EduFundContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(U id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(U id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
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
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
           var addEntity = await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();

            return entity;
        }

        public EntityState Update(T entity)
        {
            return dbSet.Update(entity).State;
           // _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(T entity)
        {

            //_dbContext.Entry(entity).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
        //    _dbContext.Set<T>().Remove(entity);
        //    await _dbContext.SaveChangesAsync();
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
    }
}
