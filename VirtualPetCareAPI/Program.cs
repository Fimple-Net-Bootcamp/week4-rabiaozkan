using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VirtualPetCareAPI.Data;
using Microsoft.OpenApi.Models;
using AutoMapper;
using VirtualPetCareAPI.Profiles;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using VirtualPetCareAPI.Validators;
using VirtualPetCareAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddControllers()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidation>());


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VirtualPetCareAPI", Version = "v1" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VirtualPetCareAPI v1"));
}

app.UseHttpsRedirection();

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
