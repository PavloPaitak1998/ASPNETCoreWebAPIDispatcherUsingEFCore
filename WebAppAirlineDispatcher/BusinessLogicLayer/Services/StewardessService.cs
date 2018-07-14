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
    public class StewardessService : IStewardessService
    {
        IRepository<Stewardess> stewardessRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StewardessDTO, Stewardess>()).CreateMapper();

        public StewardessService(IRepository<Stewardess> _stewardessRepository)
        {
            stewardessRepository = _stewardessRepository;
        }

        public StewardessDTO GetEntity(int id)
        {
            var stewardess = stewardessRepository.Get(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            return mapper.Map<StewardessDTO>(stewardess);
        }

        public IEnumerable<StewardessDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Stewardess>, List<StewardessDTO>>(stewardessRepository.GetAll());
        }

        public void CreateEntity(StewardessDTO stewardessDTO)
        {

            stewardessRepository.Create(mapper.Map<Stewardess>(stewardessDTO));
        }

        public void UpdateEntity(int id, StewardessDTO stewardessDTO)
        {
            var stewardess = stewardessRepository.Get(stewardessDTO.Id);

            if (stewardess == null)
                throw new ValidationException($"Flight with this number {stewardessDTO.Id} not found");

            if (stewardessDTO.FirstName != null)
                stewardess.FirstName = stewardessDTO.FirstName;
            if (stewardessDTO.LastName != null)
                stewardess.LastName = stewardessDTO.LastName;
            if (stewardessDTO.BirthDate != DateTime.MinValue)
                stewardess.BirthDate = stewardessDTO.BirthDate;
            if (stewardessDTO.CrewId >0)
                stewardess.CrewId = stewardessDTO.CrewId;

            stewardessRepository.Update();
        }

        public void DeleteAllEntities()
        {
            stewardessRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var stewardess = stewardessRepository.Get(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            stewardessRepository.Delete(stewardess);
        }
    }
}
