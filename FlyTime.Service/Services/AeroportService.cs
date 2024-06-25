using FlyTime.Core;
using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using FlyTime.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    // public class AeroportService : IAeroportService
    // {
    //     public readonly IAeroportRepository repo;

    //     public Task<Aeroport> CreateAeroport(Aeroport aeroport)
    //     {
    //         return repo.AddAsync(aeroport);
    //     }

    //     public void DeleteAeroport(int id)
    //     {
    //         Aeroport aeroportToDelete = repo.GetByIdAsync(id).Result;
    //         repo.Remove(aeroportToDelete);
    //     }

    //     public Task<IEnumerable<Aeroport>> GetAeroportByCity(string city)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public Task<IEnumerable<Aeroport>> GetAeroportByCountry(string name)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public ValueTask<Aeroport> GetAeroportById(int id)
    //     {
    //         return repo.GetByIdAsync(id);
    //     }

    //     public Task<Aeroport> GetAeroportByName(string name)
    //     {
    //         return repo.GetByName(name);
    //     }

    //     public Task<IEnumerable<Aeroport>> GetAllAeroports()
    //     {
    //         return repo.GetAllAsync();
    //     }

    //     public Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id)
    //     {
    //         ValueTask<Aeroport> checkAeroport = repo.GetByIdAsync(id);

    //         Aeroport aeroportFromDb;

    //         if (checkAeroport.IsCompletedSuccessfully)
    //         {
    //             aeroportFromDb = checkAeroport.Result;

    //             aeroportFromDb.Name = aeroport.Name;
    //             aeroportFromDb.Code = aeroport.Code;
    //             aeroportFromDb.City = aeroport.City;
    //             aeroportFromDb.Country = aeroport.Country;

    //             return repo.AddAsync(aeroportFromDb);
    //         }
    //         else
    //         {
    //             throw new Exception("Operation Canceled or Aeroport not found");
    //         }

    //         return null;
    //     }
    // }

     public class AeroportService : IAeroportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AeroportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Aeroport> CreateAeroport(Aeroport aeroport)
        {
            await _unitOfWork.Aeroports.AddAsync(aeroport);
            await _unitOfWork.CommitAsync();
            return aeroport;
        }

        public async void DeleteAeroport(int id)
        {
            var aeroportToDelete = await _unitOfWork.Aeroports.GetByIdAsync(id);
            _unitOfWork.Aeroports.Remove(aeroportToDelete);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCity(string city)
        {
            return _unitOfWork.Aeroports.GetAllByCity(city);
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCountry(string country)
        {
            return _unitOfWork.Aeroports.GetAllByCountry(country);
        }

        public ValueTask<Aeroport> GetAeroportById(int id)
        {
            return _unitOfWork.Aeroports.GetByIdAsync(id);
        }

        public Task<Aeroport> GetAeroportByName(string name)
        {
            return _unitOfWork.Aeroports.GetByName(name);
        }

        public Task<IEnumerable<Aeroport>> GetAllAeroports()
        {
            return _unitOfWork.Aeroports.GetAllAsync();
        }

        public async Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id)
        {
            var existingAeroport = await _unitOfWork.Aeroports.GetByIdAsync(id);

            if (existingAeroport == null)
            {
                throw new Exception("Aeroport not found");
            }

            // Mettre à jour les propriétés de l'aéroport existant avec les nouvelles valeurs
            existingAeroport.Name = aeroport.Name;
            existingAeroport.Code = aeroport.Code;
            existingAeroport.City = aeroport.City;
            existingAeroport.Country = aeroport.Country;

            await _unitOfWork.Aeroports.AddAsync(existingAeroport);
            await _unitOfWork.CommitAsync();

            return existingAeroport;
        }

        public Task<Aeroport> GetAeroportByCode(string code)
        {
            var obj = _unitOfWork.Aeroports.GetByCode(code).Result;
            if (obj == null)
            {
                obj = new Aeroport();
                obj.Code = code;
                obj.Name = code;
                obj.City = code;
                obj.Country = code;

                 _unitOfWork.Aeroports.AddAsync(obj);
                 _unitOfWork.CommitAsync();
            }
            return _unitOfWork.Aeroports.GetByCode(code);
        }
    }
}
