using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.DataAccess.Interfaces;

namespace EduHome.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepostitory
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
