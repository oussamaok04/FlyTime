using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlyTime.Data.Repositories
{
    public class VolRepository : Repository<Vol>, IVolRepository
    {
        public VolRepository(FlyTimeDbContext context) : base(context)
        { }

        private FlyTimeDbContext FlyTimeDbContext
        {
            get { return Context as FlyTimeDbContext; }
        }

        public async Task<IEnumerable<Vol>> GetAllWithActivities()
        {
            return await FlyTimeDbContext.Vols
                .Include(v => v.Activities)
                .ToListAsync();
        }

        public async Task<Vol> GetWithActivitiesById(int id)
        {
            return await FlyTimeDbContext.Vols
                .Include(v => v.Activities)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}