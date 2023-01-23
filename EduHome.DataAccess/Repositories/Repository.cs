using EduHome.Core.Interfaces;
using EduHome.DataAccess.Contexts;
using EduHome.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduHome.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly AppDbContext _context;
        private DbSet<T> _table;


        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }



        public IQueryable<T> FindAll()
        {
            return _table.AsQueryable();
        }


        public async Task <T?> FindByIdAsync(int id)
        {
            return  await _table.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool Istracking = false)
        {
            if (Istracking)
            {
                return _table.Where(expression);
            }
            return _table.Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
