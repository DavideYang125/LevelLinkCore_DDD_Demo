using LevelLinkCore.Domain.BaseModel;
using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LevelLinkCore.InfrastructureTest.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity:AggregateRoot
    {
        internal LevelLinkContext _dbContext;
        internal DbSet<TEntity> Table;
        public BaseRepository(LevelLinkContext dbDbContext)
        {
            _dbContext = dbDbContext;
            this.Table = _dbContext.Set<TEntity>();
        }
        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                Table.Attach(entity);
            }
            Table.Remove(entity);
        }

        public virtual void DeleteById(object Id)
        {
            TEntity entityToDelete = Table.Find(Id);
            Delete(entityToDelete);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public virtual List<TEntity> GetAllList()
        {
            return Table.AsQueryable().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {        
            IQueryable<TEntity> query = Table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return Table.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Table.Add(entity);
        }


        public virtual void Update(TEntity entity)
        {
            Table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        //private TEntity GetFromChangeTrackerOrNull(int id)
        //{
        //    var entry = _dbContext.ChangeTracker.Entries()
        //        .FirstOrDefault(
        //            ent =>
        //                ent.Entity is TEntity &&
        //                EqualityComparer.Default.Equals(id, ((TEntity)ent.Entity))
        //        );

        //    return entry?.Entity as TEntity;
        //}
    }
}
