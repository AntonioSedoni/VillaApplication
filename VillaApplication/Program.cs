
using Microsoft.EntityFrameworkCore;
using Serilog;
using VillaApplication.Configuration;
using VillaApplication.Service;
using VillaApplication.Service.Impl;

namespace VillaApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Serializer logs
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("logs/log-.txt", rollingInterval:RollingInterval.Day).CreateLogger();
            builder.Host.UseSerilog();

            //Add SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
            });

            // Add services to the container.
            builder.Services.AddScoped<IVillaService, VillaService>();
            builder.Services.AddScoped<IOwnerService, OwnerService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //AutoMapper enable
            builder.Services.AddAutoMapper(typeof(Program));

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
        }
    }
}
