using FlyTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlyTime.Data
{
    public class FlyTimeDbContext : DbContext
    {
        public DbSet<Activity> Activities {get; set;}
        public DbSet<Vol> Vols {get; set;}
        public DbSet<Pilot> Pilots {get; set;}
        public DbSet<Aeroport> Aeroports {get; set;}

        public FlyTimeDbContext(DbContextOptions<FlyTimeDbContext> options) : base(options)
        {}

        //TODO : Ajouter configurations
    }
}