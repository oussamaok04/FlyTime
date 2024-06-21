﻿using FlyTime.Core;
using FlyTime.Core.Models;
using FlyTime.Core.Repositories;
using FlyTime.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    // public class PilotService : IPilotService
    // {
    //     private readonly IPilotRepository repo;

    //     public Task<Pilot> CreatePilot(Pilot pilot)
    //     {
    //         return repo.AddAsync(pilot);
    //     }

    //     public void DeletePilot(Pilot pilot)
    //     {
    //         repo.Remove(pilot);
    //     }

    //     public Task<IEnumerable<Pilot>> GetAllPilots()
    //     {
    //         return repo.GetAllAsync();
    //     }

    //     public ValueTask<Pilot> GetPilotById(int id)
    //     {
    //         return repo.GetByIdAsync(id);
    //     }

    //     public Task<Pilot> UpdatePilote(Pilot pilot, int id)
    //     {
    //         ValueTask<Pilot> checkPilot = repo.GetByIdAsync(id);

    //         Pilot pilotFromDb;

    //         if (checkPilot.IsCompletedSuccessfully)
    //         {
    //             pilotFromDb = checkPilot.Result;

    //             pilotFromDb.Email = pilot.Email;
    //             pilotFromDb.Password = pilot.Password;
    //             pilotFromDb.Matricule = pilot.Matricule;

    //             return repo.AddAsync(pilotFromDb);
    //         }
    //         else
    //         {
    //             throw new Exception("Operation Canceled or Aeroport not found");
    //         }

    //         return null;
    //     }
    // }

    public class PilotService : IPilotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PilotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pilot> CreatePilot(Pilot pilot)
        {
            await _unitOfWork.Pilots.AddAsync(pilot);
            await _unitOfWork.CommitAsync();
            return pilot;
        }

        public async void DeletePilot(int id)
        {
            var pilotToDelete = await _unitOfWork.Pilots.GetByIdAsync(id);
            _unitOfWork.Pilots.Remove(pilotToDelete);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Pilot>> GetAllPilots()
        {
            return _unitOfWork.Pilots.GetAllAsync();
        }

        public ValueTask<Pilot> GetPilotById(int id)
        {
            return _unitOfWork.Pilots.GetByIdAsync(id);
        }

        public async Task<Pilot> UpdatePilot(Pilot pilot, int id)
        {
            var existingPilot = await _unitOfWork.Pilots.GetByIdAsync(id);

            if (existingPilot == null)
            {
                throw new Exception("Pilot not found");
            }

            // Mettre à jour les propriétés du pilote existant avec les nouvelles valeurs
            existingPilot.Email = pilot.Email;
            existingPilot.Password = pilot.Password;
            existingPilot.Matricule = pilot.Matricule;

            await _unitOfWork.Pilots.AddAsync(existingPilot);
            await _unitOfWork.CommitAsync();

            return existingPilot;
        }


    }
}
