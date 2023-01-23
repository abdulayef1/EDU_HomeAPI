using EduHome.Business.DTOs.Courses;
using EduHome.Core.Entities;
using EduHome.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> FindAllAsync();
        Task<CourseDTO> FindByIdAsync(int id);
        Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course, bool>> expression);
        Task CreateAsync(CoursePostDto entity);
        Task UpdateAsync(int id ,CourseUpdateDto courseUpdateDto);
        Task DeleteAsync(int id);

    }
}
