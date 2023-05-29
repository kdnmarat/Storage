using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StorageAPI.Models.DbContexts;

var builder = WebApplication.CreateBuilder(args);
var _configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(_configuration.GetConnectionString("LocalSqlDb"));
});

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
