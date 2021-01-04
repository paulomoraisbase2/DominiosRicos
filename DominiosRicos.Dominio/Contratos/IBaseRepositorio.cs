using DominiosRicos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DominiosRicos.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);

        void Commit();

        TEntity GetId(Guid Id);

        Task<TEntity> GetIdAsync(Guid Id);

        bool Exists(Guid Id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> Including(string includeString);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);

        void DeleteAllOnSubmit(IEnumerable<TEntity> items);
    }
}