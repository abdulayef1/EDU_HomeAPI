using EduHome.Business.DTOs.Courses;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EduHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var course = await _courseService.FindByIdAsync(id);
            return Ok(course);
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var courses = await _courseService.FindAllAsync();
        return Ok(courses);
    }


    [HttpGet("searchByName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var result = await _courseService.FindByConditionAsync(c => c.Name != null ? c.Name.Contains(name) : true);
            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post(CoursePostDto coursePostDto)
    {
        try
        {
            await _courseService.CreateAsync(coursePostDto);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CourseUpdateDto courseUpdateDto)
    {
        try
        {
            await _courseService.UpdateAsync(id, courseUpdateDto);
            return Ok();
        }
        catch (BadRequestException ex)
        {
            return  BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError); 
        }

    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
           await  _courseService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }     catch (Exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }


}