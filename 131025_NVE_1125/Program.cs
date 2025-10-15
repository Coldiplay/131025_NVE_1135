
using _131025_NVE_1125.DB;
using MyMediator.Extension;
using MyMediator.Types;
using Scalar.AspNetCore;
using System.Reflection;

namespace _131025_NVE_1125
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Db131025Context>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //CQRSû
            builder.Services.AddScoped<Mediator>();
            builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                //Âêëþ÷åíèå Scalar
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
