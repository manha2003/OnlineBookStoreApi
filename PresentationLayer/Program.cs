using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using DataAccessLayer.Repository;
using BusinessLogicLayer.Mapping; // Adjust the namespace based on your actual folder structure
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataAccessLayer.Data;
using BusinessLogicLayer.Services.AuthorService;
using BusinessLogicLayer.Services.BookService;
using BusinessLogicLayer.Services.CartService;
using BusinessLogicLayer.Services.OrderService;
using BusinessLogicLayer.Services.UserService;
using DataAccessLayer.IRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Add repositories and services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OnlineBookStoreDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookStoreConnectionString")));




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
