using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, string>> orderBy = null, int? skip = null, int? take = null);


        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null, int? skip = null, int? take = null);


        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null);


        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null);


        TEntity GetById(object id);

        int GetCount(Expression<Func<TEntity, bool>> filter = null);


        bool GetExists(Expression<Func<TEntity, bool>> filter = null);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);


        IQueryable<TEntity> GetQuerable(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, string>> orderBy = null, int? skip = default(int?), int? take = default(int?));

    }
}
