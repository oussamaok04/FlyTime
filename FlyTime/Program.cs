using FlyTime.Data;
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
            builder.Services.AddDbContext<FlyTimeDbContext>(options => options.UseMySql(
                MySQLConnection, ServerVersion.AutoDetect(MySQLConnection)
                )
            );

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