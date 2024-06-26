
using RepositoryLayer.Context;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IEmployeeBusinessLayer,EmployeeServiceBusinessLayer>();
builder.Services.AddScoped<IEmployeeRepositoryLayer, EmployeeServiceRepositoryLayer>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
