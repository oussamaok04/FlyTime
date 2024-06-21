using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlyTime.Data.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(FlyTimeDbContext context) : base(context)
        { }

        private FlyTimeDbContext FlyTimeDbContext
        {
            get { return Context as FlyTimeDbContext; }
        }

        public async Task<Activity> GetByEndTime(DateTime endTime)
        {
            return await FlyTimeDbContext.Activities
                .FirstOrDefaultAsync(a => a.EndTime == endTime);
        }

        public async Task<Activity> GetByStartTime(DateTime startTime)
        {
            return await FlyTimeDbContext.Activities
                .FirstOrDefaultAsync(a => a.StartTime == startTime);
        }

        public async Task<IEnumerable<Activity>> GetActivityByVol(Vol vol)
        {
            return await FlyTimeDbContext.Activities
                .Where(a => a.Vol.Id == vol.Id)
                .ToListAsync();
        }
    }
}