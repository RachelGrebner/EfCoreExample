using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EfLunchAndLearnDbFirst.Interfaces
{
    public interface ICrud<TEntity>
    {
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> AllInclude
            (params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindByInclude
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAllIncluding
            (params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Delete(TEntity id);
        int Insert(TEntity entity);
        TEntity FindByKeyInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FindByKey(int id);
    }
}
