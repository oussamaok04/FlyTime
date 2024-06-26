using FlyTime.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IAeroportService
    {
        Task<IEnumerable<Aeroport>> GetAllAeroports();
        ValueTask<Aeroport> GetAeroportById(int id);
        Task<IEnumerable<Aeroport>> GetAeroportByCity(string city);
        Task<Aeroport> GetAeroportByCode(string code);
        Task<IEnumerable<Aeroport>> GetAeroportByCountry(string country);
        Task<Aeroport> GetAeroportByName(string name);
        Task<Aeroport> CreateAeroport(Aeroport aeroport);
        Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id);
        void DeleteAeroport(int id);
    }
}
