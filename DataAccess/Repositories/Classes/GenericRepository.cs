using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(AppDbContext _appDbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _appDbContext.Set<TEntity>().Where(e => e.IsDeleted != true).ToList();
            else
            {
                var result = _appDbContext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
                return result;

            }
        }
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {

            return _appDbContext.Set<TEntity>()
              .Select(selector).ToList();


        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _appDbContext.Set<TEntity>()
                   .Where(e => e.IsDeleted != true)
                   .Where(filter)
                   .ToList();
        }
        //Get By Id

        public TEntity? GetById(int id) => _appDbContext.Set<TEntity>().Find(id);

        //Add

        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }
        //Edit
        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }
        //Delete
        public void Remove(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }
    }
}
