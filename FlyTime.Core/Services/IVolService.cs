using FlyTime.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IVolService
    {
        Task<IEnumerable<Vol>> GetAllVols();
        ValueTask<Vol> GetVolById(int id);
        Task<Vol> CreateVol(Vol vol);
        Task<Vol> UpdateVol(Vol vol, int id);
        void DeleteVol(Vol vol, int id);
    }
}
