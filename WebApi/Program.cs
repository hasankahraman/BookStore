using Microsoft.Extensions.DependencyInjection;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDBContext>(options => options.UseInMemoryDatabase("BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddDbContext<BookStoreDBContext>(x => x.DatabaseName("BookStoreDB"));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();
