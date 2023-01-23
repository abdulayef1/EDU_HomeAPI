using EduHome.Business.DTOs.Categories;
using EduHome.Core.Entities;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> FindAllAsync();
    Task<List<Category>> FindByCondition(Expression<Func<Category, bool>> expression, bool Istracking = false);
    Task<Category> FindByIdAsync(int id);
    void Create(Category entity);
    void Update(Category entity);
    void Delete(Category entity);
}
