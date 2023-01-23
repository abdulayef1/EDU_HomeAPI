using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.DataAccess.Interfaces;

namespace EduHome.DataAccess.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }
}
