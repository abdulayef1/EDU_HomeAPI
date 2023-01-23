using EduHome.Core.Interfaces;
using System.Linq.Expressions;

namespace EduHome.DataAccess.Interfaces;

public interface IRepository<T> where T : class, IEntity, new()
{

    IQueryable<T> FindAll();
    Task <T?> FindByIdAsync(int id);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool Istracking = false);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();
}
