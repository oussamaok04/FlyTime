using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlyTime.Data.Repositories
{
    public class AeroportRepository : Repository<Aeroport>, IAeroportRepository
    {
        public AeroportRepository(FlyTimeDbContext context) : base(context)
        { }

        private FlyTimeDbContext FlyTimeDbContext
        {
            get { return Context as FlyTimeDbContext; }
        }

        public async Task<Aeroport> GetByCode(int id)
        {
            return await FlyTimeDbContext.Aeroports
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Aeroport>> GetAllByCity(string city)
        {
            return await FlyTimeDbContext.Aeroports
                .Where(a => a.City == city)
                .ToListAsync();
        }

        public async Task<IEnumerable<Aeroport>> GetAllByCountry(string country)
        {
            return await FlyTimeDbContext.Aeroports
                .Where(a => a.Country == country)
                .ToListAsync();
        }

        public async Task<Aeroport> GetByName(string name)
        {
            return await FlyTimeDbContext.Aeroports
                .FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}