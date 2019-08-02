using PlanetsApi.Models;
using PlanetsApi.Repository.Context;
using PlanetsApi.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PlanetsApi.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly MyContext _myContext;

        public RepositoryBase(MyContext myContext)
        {
            _myContext = myContext;
        }

        public T Create(T Entity)
        {
            return _myContext.Set<T>().Add(Entity).Entity;
        }

        public void Delete(int id)
        {
            var entity = _myContext.Set<T>().FirstOrDefault(e => e.Id == id);
            _myContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _myContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _myContext.Set<T>().Where(expression);
        } 

        public int SaveChanges()
        {
            return _myContext.SaveChanges();
        }
    }
}
