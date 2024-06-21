using FlyTime.Core;
using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using FlyTime.Core.Services;

namespace FlyTime.Service.Services
{
    //public class ActivityService : IActivityService
    //{
    //     private readonly IActivityRepository activityRepository;

    //     public Task<Activity> CreateActivity(Activity activity)
    //     {
    //         return activityRepository.AddAsync(activity);
    //     }

    //     public void DeleteActivity(Activity activity)
    //     {
    //         activityRepository.Remove(activity);
    //     }

    //     public Task<Activity> GetActivityByEndTime(DateTime endTime)
    //     {
    //         return activityRepository.GetByEndTime(endTime);
    //     }

    //     public ValueTask<Activity> GetActivityById(int id)
    //     {
    //         return activityRepository.GetByIdAsync(id);
    //     }

    //     public Task<Activity> GetActivityByStartTime(DateTime startTime)
    //     {
    //         return activityRepository.GetByStartTime(startTime);
    //     }

    //     //***********************TODO********************************
    //     public Task<IEnumerable<Activity>> GetActivityByVol(Vol vol)
    //     {
    //         throw new NotImplementedException();
    //     }
    //     //***********************************************************

    //     public Task<Activity> UpdateActivity(Activity activity, int id)
    //     {
    //         ValueTask<Activity> checkActivity = activityRepository.GetByIdAsync(id);

    //         Activity activityFromDb;

    //         if (checkActivity.IsCompletedSuccessfully)
    //         {
    //             activityFromDb = checkActivity.Result;

    //             activityFromDb.FromDestination = activity.FromDestination;
    //             activityFromDb.ToDestination = activity.ToDestination;
    //             activityFromDb.StartTime = activity.StartTime;
    //             activityFromDb.EndTime = activity.EndTime;

    //             return activityRepository.AddAsync(activityFromDb);
    //         }
    //         else
    //         {
    //             throw new Exception("Operation Canceled or Activity not found");
    //         }

    //         return null;
    //     }
    // }

    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> CreateActivity(Activity activity)
        {
            await _unitOfWork.Activities.AddAsync(activity);
            await _unitOfWork.CommitAsync();
            return activity;
        }

        public async void DeleteActivity(Activity activity)
        {
            _unitOfWork.Activities.Remove(activity);
            await _unitOfWork.CommitAsync();
        }

        public Task<Activity> GetActivityByEndTime(DateTime endTime)
        {
            return _unitOfWork.Activities.GetByEndTime(endTime);
        }

        public ValueTask<Activity> GetActivityById(int id)
        {
            return _unitOfWork.Activities.GetByIdAsync(id);
        }

        public Task<Activity> GetActivityByStartTime(DateTime startTime)
        {
            return _unitOfWork.Activities.GetByStartTime(startTime);
        }

        // Méthode pour récupérer les activités par vol
        public Task<IEnumerable<Activity>> GetActivityByVol(Vol vol)
        {
            return _unitOfWork.Activities.GetActivityByVol(vol);
        }

        public async Task<Activity> UpdateActivity(Activity activity, int id)
        {
            var existingActivity = await _unitOfWork.Activities.GetByIdAsync(id);

            if (existingActivity == null)
            {
                throw new Exception("Activity not found");
            }

            // Mettre à jour les propriétés de l'activité existante avec les nouvelles valeurs
            existingActivity.FromDestination = activity.FromDestination;
            existingActivity.ToDestination = activity.ToDestination;
            existingActivity.StartTime = activity.StartTime;
            existingActivity.EndTime = activity.EndTime;

            await _unitOfWork.Activities.AddAsync(existingActivity);
            await _unitOfWork.CommitAsync();

            return existingActivity;
        }

    }
}
