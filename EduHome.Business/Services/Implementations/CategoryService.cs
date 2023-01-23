using AutoMapper;
using EduHome.Business.DTOs.Categories;
using EduHome.Business.DTOs.Courses;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.DataAccess.Interfaces;
using EduHome.DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Implementations;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepostitory _repostitory;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepostitory repostitory, IMapper mapper)
    {
        _repostitory = repostitory;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> FindAllAsync()
    {
       var catagories= await _repostitory.FindAll().ToListAsync();

        var result = _mapper.Map<List<CategoryDto>>(catagories);
        throw new Exception();
    }

    public void Create(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> FindByCondition(Expression<Func<Category, bool>> expression, bool Istracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<Category> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }
}
