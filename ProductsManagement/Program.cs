using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Repositories;
using ProductsManagementBusenssLogic.ComputersBusinessLogic;
using ProductsManagementBusenssLogic.Services;
using System.Text.Json.Serialization;


//using ProductsManagement.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services and reference for the database for Computer
builder.Services.AddScoped<IComputerService, ComputerService>();


//Services and reference for the database for OracleProduct
builder.Services.AddScoped<IOracleProductService, OracleProductService>();

//Services for the repositrories and interfaces in data acess layer
builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
builder.Services.AddScoped<IOracleProductRepository, OracleProductRepository>();

builder.Services.AddDbContext<ProductDbContext>();

//Services for AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Services to ignore recursion and escape the loop 
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7154/api",
                                              "http://localhost:3000");
                      });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
