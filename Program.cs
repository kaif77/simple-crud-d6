global using simple_crud.Entity;
global using simple_crud.Models;
global using simple_crud.Services;
global using simple_crud.DB;
global using simple_crud.Controllers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => build.WithOrigins("http://127.0.0.1:5173").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<ProgrammeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

builder.Services.AddTransient<ProgrammeService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
// app.UseCors(options =>
// {
//     options
//     .AllowAnyOrigin()
//     .AllowAnyMethod()
//     .AllowAnyHeader();
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
