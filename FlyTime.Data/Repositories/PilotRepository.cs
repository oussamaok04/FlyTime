using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlyTime.Data.Repositories
{
    public class PilotRepository : Repository<Pilot>, IPilotRepository
    {
        public PilotRepository(FlyTimeDbContext context) : base(context)
        { }

        private FlyTimeDbContext FlyTimeDbContext
        {
            get { return Context as FlyTimeDbContext; }
        }

        public async Task<IEnumerable<Pilot>> GetAllWithVolsAsync()
        {
            return await FlyTimeDbContext.Pilots
                .Include(p => p.Vols)
                .ToListAsync();
        }

        public async Task<Pilot> GetWithVolsByIdAsync(int id)
        {
            return await FlyTimeDbContext.Pilots
                .Include(p => p.Vols)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}