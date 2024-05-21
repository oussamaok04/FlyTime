using FlyTime.Core.Models;
using FlyTime.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    public class VolService : IVolService
    {
        public Task<Pilot> CreatePilot(Pilot pilot)
        {
            throw new NotImplementedException();
        }

        public void DeletePilot(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pilot>> GetAllPilots()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Pilot> GetPilotById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pilot> UpdatePilote(Pilot pilot)
        {
            throw new NotImplementedException();
        }
    }
}
