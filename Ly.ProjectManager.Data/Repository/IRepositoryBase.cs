
using Ly.ProjectManager.Code;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable
    {
        IRepositoryBase<TEntity> BeginTrans();
        int Commit();
        Task<int> CommitAsync();
        int Insert(TEntity entity);
        Task<int> InsertAsync(TEntity entity);
        int Insert(List<TEntity> entitys);
        Task<int> InsertAsync(List<TEntity> entitys);
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FindEntity(object keyValue);
        Task<TEntity> FindEntityAsync(object keyValue);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> IQueryable();
        Task<IList<TEntity>> IListAsync();
        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> IListAsync(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> FindList(Pagination pagination);
        Task<IList<TEntity>> FindListAsync(Pagination pagination);
        IList<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
        Task<IList<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
