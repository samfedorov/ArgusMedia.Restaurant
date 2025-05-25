using ArgusMedia.Restaurant.Models;
using ArgusMedia.Restaurant.Repositories;
using ArgusMedia.Restaurant.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper.EquivalencyExpression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .AddAutoMapper(cfg => { cfg.AddCollectionMappers(); });

builder.Services
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IOrderService, OrderService>()
    .AddTransient<IBillService, BillService>();

builder.Services
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddDbContext<RestaurantDbContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
