using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class FlightService:IFlightService
    {
        private IRepository<Flight> flightRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<FlightDTO,Flight > ().ForMember(x=>x.Tickets,opt=>opt.Ignore())).CreateMapper();

        public FlightService(IRepository<Flight> _flightRepository)
        {
            flightRepository = _flightRepository;
        }

        public FlightDTO GetEntity(int id)
        {
            var flight = flightRepository.Get(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            return mapper.Map<FlightDTO>(flight);

        }

        public IEnumerable<FlightDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(flightRepository.GetAll());
        }

        public void CreateEntity(FlightDTO flightDTO)
        {
            if (flightRepository.Find(f => f.Number == flightDTO.Number).Count() >0)
                throw new ValidationException($"Flight with this number {flightDTO.Number} already exist");

            flightRepository.Create(mapper.Map<FlightDTO,Flight>(flightDTO));
        }

        public void UpdateEntity(int id,FlightDTO flightDTO)
        {
            var flight = flightRepository.Get(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            if (flightDTO.PointOfDeparture!=null)
                flight.PointOfDeparture = flightDTO.PointOfDeparture;
            if (flightDTO.Destination != null)
                flight.Destination = flightDTO.Destination;
            if (flightDTO.DepartureTime != DateTime.MinValue)
                flight.DepartureTime = flightDTO.DepartureTime;
            if (flightDTO.DestinationTime != DateTime.MinValue)
                flight.DestinationTime = flightDTO.DestinationTime;

            flightRepository.Update();
        }

        public void DeleteAllEntities()
        {
            flightRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var flight = flightRepository.Get(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            flightRepository.Delete(flight);
        }

    }
}
