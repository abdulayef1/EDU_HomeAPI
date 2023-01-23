using AutoMapper;
using EduHome.Business.DTOs.Courses;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.DataAccess.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }


    public async Task<List<CourseDTO>> FindAllAsync()
    {
        var courses = await _courseRepository.FindAll().ToListAsync();
        var result = _mapper.Map<List<CourseDTO>>(courses);
        return
            result;
    }
    public async Task<CourseDTO> FindByIdAsync(int id)
    {

        var course = await _courseRepository.FindByIdAsync(id);
        if (course is null) throw new Exception();
        return _mapper.Map<CourseDTO>(course);
    }

    public async Task CreateAsync(CoursePostDto coursPostDto)
    {
        if (coursPostDto is null)
        {
            throw new ArgumentNullException(nameof(coursPostDto));
        }

        var course = _mapper.Map<Course>(coursPostDto);
        await _courseRepository.CreateAsync(course);
        await _courseRepository.SaveAsync();
    }
    public async Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course, bool>> expression)
    {
        var courses = await _courseRepository.FindByCondition(expression).ToListAsync();
        var courseDto = _mapper.Map<List<CourseDTO>>(courses);
        return courseDto;
    }
    public async Task UpdateAsync(int id, CourseUpdateDto courseUpdateDto)
    {

        if (id != courseUpdateDto.Id) throw new BadRequestException("enter valid id");
        var course = _courseRepository.FindByCondition(c => c.Id == id);
        if (course is null) throw new NotFoundException("not found");

        var newCourse = _mapper.Map<Course>(courseUpdateDto);

        _courseRepository.Update(newCourse);
        await _courseRepository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _courseRepository.FindByIdAsync(id);
        if (course is null) throw new NotFoundException("Not found");
        _courseRepository.Delete(course );
        await _courseRepository.SaveAsync();

    }




}
