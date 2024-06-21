using FlyTime.Core;
using FlyTime.Core.Repositories;
using FlyTime.Data.Repositories;

namespace FlyTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlyTimeDbContext _context;
        public IPilotRepository _pilotRepository; 
        public IVolRepository _volRepository;
        public IActivityRepository _activityRepository;
        public IAeroportRepository _aeroportRepository;

        public UnitOfWork(FlyTimeDbContext context)
        {
            _context = context;
        }

        public IPilotRepository Pilots => _pilotRepository = _pilotRepository ?? new PilotRepository(_context);
        public IVolRepository Vols => _volRepository = _volRepository ?? new VolRepository(_context);
        public IActivityRepository Activities => _activityRepository = _activityRepository ?? new ActivityRepository(_context);
        public IAeroportRepository Aeroports => _aeroportRepository = _aeroportRepository ?? new AeroportRepository(_context);
    

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
