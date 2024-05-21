using FlyTime.Core;
using FlyTime.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IActivityRepository ActivityRepository => throw new NotImplementedException();

        public IAeroportRepository AeroportRepository => throw new NotImplementedException();

        public IVolRepository VolRepository => throw new NotImplementedException();

        public IPilotRepository PilotRepository => throw new NotImplementedException();

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
