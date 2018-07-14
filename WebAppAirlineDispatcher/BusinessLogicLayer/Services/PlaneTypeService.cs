using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PlaneTypeService: IPlaneTypeService
    {
        IRepository<PlaneType> planeTypeRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneTypeDTO, PlaneType>()).CreateMapper();

        public PlaneTypeService(IRepository<PlaneType> _planeTypeRepository)
        {
            planeTypeRepository = _planeTypeRepository;
        }

        public PlaneTypeDTO GetEntity(int id)
        {
            var planeType = planeTypeRepository.Get(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            return mapper.Map<PlaneTypeDTO>(planeType);
        }

        public IEnumerable<PlaneTypeDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<PlaneType>, List<PlaneTypeDTO>>(planeTypeRepository.GetAll());
        }

        public void CreateEntity(PlaneTypeDTO planeTypeDTO)
        {
            planeTypeRepository.Create(mapper.Map<PlaneType>(planeTypeDTO));
        }

        public void UpdateEntity(int id, PlaneTypeDTO planeTypeDTO)
        {
            var planeType = planeTypeRepository.Get(planeTypeDTO.Id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {planeTypeDTO.Id} not found");

            if (planeTypeDTO.Model != null)
                planeType.Model = planeTypeDTO.Model;
            if (planeTypeDTO.Seats >0)
                planeType.Seats = planeTypeDTO.Seats;
            if (planeTypeDTO.Carrying >0)
                planeType.Carrying = planeTypeDTO.Carrying;

            planeTypeRepository.Update();
        }

        public void DeleteAllEntities()
        {
            planeTypeRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var planeType = planeTypeRepository.Get(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            planeTypeRepository.Delete(planeType);
        }
    }
}
