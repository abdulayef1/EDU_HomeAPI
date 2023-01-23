using EduHome.Business.Mappers;
using EduHome.Business.Services.Implementations;
using EduHome.Business.Services.Interfaces;
using EduHome.Business.Validators.Course;
using EduHome.Core.Entities.Identity;
using EduHome.DataAccess.Contexts;
using EduHome.DataAccess.Interfaces;
using EduHome.DataAccess.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CoursePostDtoValidator).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(CourseMapper).Assembly);
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<AppDbContextInitializer>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//bu hisseni basha dushmedim 
//using (var scope = app.Services.CreateAsyncScope())
//{
//    var init = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
//    await init.InitializeAsync();
//    await init.RoleSeedAsync();
//    await init.UserSeedAsync();
//}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
