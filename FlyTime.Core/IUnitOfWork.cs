using FlyTime.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository ActivityRepository { get; }
        IAeroportRepository AeroportRepository { get; }
        IVolRepository VolRepository { get; }
        IPilotRepository PilotRepository { get; }
        Task<int> CommitAsync();
    }
}
