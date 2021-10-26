using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Meetings.Repositories.Base
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> FindAll();

        Task<IQueryable<TEntity>> FindAllAsync();

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> FindByConditionWithTracking(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> FindByConditionWithTrackingAsync(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Detached(TEntity entity);

        void Delete(TEntity entity);
    }
}