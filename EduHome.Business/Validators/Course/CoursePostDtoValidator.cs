using EduHome.Business.DTOs.Courses;
using FluentValidation;

namespace EduHome.Business.Validators.Course;

public class CoursePostDtoValidator : AbstractValidator<CoursePostDto>
{
    public CoursePostDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("This field is requried")
            .NotNull().WithMessage("This field is requried")
            .MaximumLength(100).WithMessage("Maximum symbol:150");
        RuleFor(c => c.Description).NotEmpty().WithMessage("This field is requried")
            .NotNull().WithMessage("This field is requried")
            .MaximumLength(200).WithMessage("Maximum symbol:200");
        RuleFor(c => c.Image).NotNull().WithMessage("This field is requried")
            .NotEmpty().WithMessage("This field is requried");
    }
}
