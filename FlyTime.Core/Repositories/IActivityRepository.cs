using FlyTime.Core.Models;

namespace FlyTime.Core.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        public Task<Activity> GetByEndTime(TimeSpan endTime);
        public Task<Activity> GetByStartTime(TimeSpan startTime);
        Task<IEnumerable<Activity>> GetActivityByVol(Vol vol);
        Task<List<Activity>> GetAllActivities();

    }
}