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
    public class PlaneService: IPlaneService
    {
        IRepository<Plane> planeRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneDTO, Plane>()).CreateMapper();

        public PlaneService(IRepository<Plane> _planeRepository)
        {
            planeRepository = _planeRepository;
        }

        public PlaneDTO GetEntity(int id)
        {
            var plane = planeRepository.Get(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            return mapper.Map<PlaneDTO>(plane);
        }

        public IEnumerable<PlaneDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Plane>, List<PlaneDTO>>(planeRepository.GetAll());
        }

        public void CreateEntity(PlaneDTO planeDTO)
        {
            planeRepository.Create(mapper.Map<Plane>(planeDTO));
        }

        public void UpdateEntity(int id, PlaneDTO planeDTO)
        {
            var plane = planeRepository.Get(planeDTO.Id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {planeDTO.Id} not found");

            if (planeDTO.PlaneTypeId > 0)
                plane.PlaneTypeId = planeDTO.PlaneTypeId;
            if (planeDTO.Name != null)
                plane.Name = planeDTO.Name;
            if (planeDTO.Lifetime != TimeSpan.Parse("00:00:00"))
                plane.Lifetime = planeDTO.Lifetime;
            if (planeDTO.ReleaseDate != DateTime.MinValue)
                plane.ReleaseDate = planeDTO.ReleaseDate;

            planeRepository.Update();
        }

        public void DeleteAllEntities()
        {
            planeRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var plane = planeRepository.Get(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            planeRepository.Delete(plane);
        }
    }
}
