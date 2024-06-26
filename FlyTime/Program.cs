using FlyTime.Core;
using FlyTime.Core.Repositories;
using FlyTime.Core.Services;
using FlyTime.Data;
using FlyTime.Data.Repositories;
using FlyTime.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace FlyTime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MySQLConnection = builder.Configuration.GetConnectionString("MySQLConnectionString");

            // Add services to the container.
            builder.Services.AddDbContext<FlyTimeDbContext>(options =>
                options.UseMySql(MySQLConnection, ServerVersion.AutoDetect(MySQLConnection))
            );

            builder.Services.AddScoped<FlyTimeDbContext>();

            // Register UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register repositories
            builder.Services.AddScoped<IVolRepository, VolRepository>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
            builder.Services.AddScoped<IAeroportRepository, AeroportRepository>();
            builder.Services.AddScoped<IPilotRepository, PilotRepository>();

            // Register services
            builder.Services.AddScoped<IVolService, VolService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IAeroportService, AeroportService>();
            builder.Services.AddScoped<IPilotService, PilotService>();

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
        }
    }
}