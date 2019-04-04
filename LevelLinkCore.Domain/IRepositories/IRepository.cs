using LevelLinkCore.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LevelLinkCore.Domain.IRepositories
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        #region get
        IQueryable<TEntity> GetAll();

        List<TEntity> GetAllList();

        /// <summary>
        /// 通过lambda表达式查询list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(object id);
        #endregion

        #region add
        void Insert(TEntity entity);
        #endregion

        #region update
        void Update(TEntity entity);
        #endregion

        #region delete
        void Delete(TEntity entity);

        void DeleteById(object Id);
        #endregion
    }
}
