using ProductsDemoApi.Context;
using ProductsDemoApi.Models;
using ProductsDemoApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ProductsDemoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProductContext>();

            builder.Services.AddScoped<IDataRepository<Product>, ProductsRepository>();

            var app = builder.Build();

            app.UseCors(policy => policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

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
        }
    }
}
