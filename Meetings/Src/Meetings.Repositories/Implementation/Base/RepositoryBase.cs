using Meetings.EF;
using Meetings.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Meetings.Repositories.Implementation.Base
{
    internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        #region Constructors

        public RepositoryBase(MeetingsContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        #endregion Constructors

        #region Properties

        protected MeetingsContext RepositoryContext { get; set; }

        #endregion Properties



        #region Methods

        public IQueryable<TEntity> FindAll()
        {
            return this.RepositoryContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            return await Task.FromResult(RepositoryContext.Set<TEntity>().AsNoTracking());
        }

        public void Detached(TEntity entity)
        {
            this.RepositoryContext.Entry(entity).State = EntityState.Detached;
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this.RepositoryContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(this.RepositoryContext.Set<TEntity>().Where(expression).AsNoTracking());
        }

        public IQueryable<TEntity> FindByConditionWithTracking(Expression<Func<TEntity, bool>> expression)
        {
            return this.RepositoryContext.Set<TEntity>().Where(expression);
        }

        public async Task<IQueryable<TEntity>> FindByConditionWithTrackingAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(this.RepositoryContext.Set<TEntity>().Where(expression));
        }

        public void Create(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Remove(entity);
        }

        #endregion Methods
    }
}