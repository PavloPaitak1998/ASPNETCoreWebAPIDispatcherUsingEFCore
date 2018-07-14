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
    public class DepartureService : IDepartureService
    {
        private IRepository<Departure> departureRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartureDTO, Departure>()).CreateMapper();

        public DepartureService(IRepository<Departure> _departureRepository)
        {
            departureRepository = _departureRepository;
        }

        public DepartureDTO GetEntity(int id)
        {
            var departure = departureRepository.Get(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            return mapper.Map<DepartureDTO>(departure);
        }

        public IEnumerable<DepartureDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Departure>, List<DepartureDTO>>(departureRepository.GetAll());
        }

        public void CreateEntity(DepartureDTO departureDTO)
        {
            departureRepository.Create(mapper.Map<Departure>(departureDTO));
        }

        public void UpdateEntity(int id,DepartureDTO departureDTO)
        {
            var departure = departureRepository.Get(departureDTO.Id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {departureDTO.Id} not found");

            if (departureDTO.FlightNumber > 0)
                departure.FlightNumber = departureDTO.FlightNumber;
            if (departureDTO.CrewId > 0)
                departure.CrewId = departureDTO.CrewId;
            if (departureDTO.PlaneId > 0)
                departure.PlaneId = departureDTO.PlaneId;
            if (departureDTO.Time != DateTime.MinValue)
                departure.Time = departureDTO.Time;

            departureRepository.Update();
        }

        public void DeleteAllEntities()
        {
            departureRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var departure = departureRepository.Get(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            departureRepository.Delete(departure);
        }
    }
}
