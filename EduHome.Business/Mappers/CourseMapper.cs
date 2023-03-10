using AutoMapper;
using EduHome.Business.DTOs.Courses;
using EduHome.Core.Entities;

namespace EduHome.Business.Mappers;

public class CourseMapper:Profile
{
	public CourseMapper()
	{
        CreateMap<Course, CourseDTO>().ReverseMap();
        CreateMap<CoursePostDto, Course>().ReverseMap();
        CreateMap<CourseUpdateDto,Course>().ReverseMap();

    }
}
