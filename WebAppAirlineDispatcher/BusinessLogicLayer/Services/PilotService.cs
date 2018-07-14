using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PilotService : IPilotService
    {
        IRepository<Pilot> pilotRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PilotDTO, Pilot>()).CreateMapper();

        public PilotService(IRepository<Pilot> _pilotRepository)
        {
            pilotRepository = _pilotRepository;
        }

        public PilotDTO GetEntity(int id)
        {
            var pilot = pilotRepository.Get(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            return mapper.Map<PilotDTO>(pilot);
        }

        public IEnumerable<PilotDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Pilot>, List<PilotDTO>>(pilotRepository.GetAll());
        }

        public void CreateEntity(PilotDTO pilotDTO)
        {
            pilotRepository.Create(mapper.Map<Pilot>(pilotDTO));
        }

        public void UpdateEntity(int id,PilotDTO pilotDTO)
        {
            var pilot = pilotRepository.Get(pilotDTO.Id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {pilotDTO.Id} not found");

            if (pilotDTO.FirstName != null)
                pilot.FirstName = pilotDTO.FirstName;
            if (pilotDTO.LastName != null)
                pilot.LastName = pilotDTO.LastName;
            if (pilotDTO.BirthDate != DateTime.MinValue)
                pilot.BirthDate = pilotDTO.BirthDate;
            if (pilotDTO.Experience != null)
                pilot.Experience = pilotDTO.Experience.Value;

            pilotRepository.Update();
        }

        public void DeleteAllEntities()
        {
            pilotRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var pilot = pilotRepository.Get(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            pilotRepository.Delete(pilot);
        }
    }
}
