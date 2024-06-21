using FlyTime.Core.Repositories;

namespace FlyTime.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPilotRepository Pilots { get; }
        IVolRepository Vols { get; }
        IActivityRepository Activities { get; }
        IAeroportRepository Aeroports { get; }

        Task<int> CommitAsync();
    }
}
