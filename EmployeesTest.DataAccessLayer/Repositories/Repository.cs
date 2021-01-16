using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected Entities.Database _db;
        protected UnitOfWork _uow;

        protected Repository(UnitOfWork uow)
        {
            _uow = uow;
            _db = _uow._context;
            _db.Configuration.LazyLoadingEnabled = false;
            //_db.Configuration.AutoDetectChangesEnabled = false;
        }
        public virtual void Create(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }


        public virtual void Delete(TEntity entity)
        {
            var dbSet = _db.Set<TEntity>();

            dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null, int? skip = default(int?), int? take = default(int?))
        {
            return GetQuerable(filter, orderBy, skip, take).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, string>> orderBy = null, int? skip = default(int?), int? take = default(int?))
        {
            return GetQuerable(null, orderBy, skip, take).ToList();
        }

        public TEntity GetById(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQuerable(filter).Count();
        }

        public virtual bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQuerable(filter).Any();
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null)
        {
            return GetQuerable(filter, orderBy).FirstOrDefault();
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQuerable(filter, null).SingleOrDefault();
        }

        public virtual IQueryable<TEntity> GetQuerable(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null, int? skip = default(int?), int? take = default(int?))
        {

            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            if (skip.HasValue)
            {
                skip--;
                query = query.Skip((skip ?? 0) * take.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }


            return query;
        }


        public virtual void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }





    }
}
