using Microsoft.EntityFrameworkCore;
using ODEV_2.Data;
using ODEV_2.Repositories;
using ODEV_2.Repositories.Abstract;
using ODEV_2.Services;
using ODEV_2.Services.Abstract;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IBootcampRepository<>), typeof(BootcampRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


builder.Services.AddDbContext<DatabaseContext>(
    o=>o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

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
