using System;
using System.Linq;
using System.Linq.Expressions;

namespace PlanetsApi.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T Entity);
        void Delete(int id);
        int SaveChanges();
    }
}
