using AutoMapper;
using EduHome.Business.DTOs.Categories;
using EduHome.Core.Entities;

namespace EduHome.Business.Mappers;

public class CategoryMapper:Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
    
}
