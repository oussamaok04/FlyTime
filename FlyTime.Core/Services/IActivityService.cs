using FlyTime.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IActivityService
    {
        Task<Activity> CreateActivity(Activity activity);
        Task<Activity> UpdateActivity(Activity activity, int id);
        void DeleteActivity(Activity activity);
        ValueTask<Activity> GetActivityById(int id);
        Task<Activity> GetActivityByStartTime(TimeSpan startTime);
        Task<Activity> GetActivityByEndTime(TimeSpan endTime);
        Task<IEnumerable<Activity>> GetActivityByVol(int id);
        Task<List<Activity>> GetAllActivities();
    }
}
