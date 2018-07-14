using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class CrewService : ICrewService
    {
        private IRepository<Crew> crewRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<CrewDTO, Crew>().ForMember(x=>x.Stewardesses,opt=>opt.Ignore())).CreateMapper();


        public CrewService(IRepository<Crew> _crewRepository)
        {
            crewRepository = _crewRepository;
        }

        public CrewDTO GetEntity(int id)
        {
            var crew = crewRepository.Get(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            return mapper.Map<CrewDTO>(crew);
        }

        public IEnumerable<CrewDTO> GetEntities()
        {
            return mapper.Map<IEnumerable<Crew>, List<CrewDTO>>(crewRepository.GetAll());
        }

        public void CreateEntity(CrewDTO crewDTO)
        {
            
            crewRepository.Create(mapper.Map<CrewDTO,Crew>(crewDTO));
        }

        public void UpdateEntity(int id,CrewDTO crewDTO)
        {
            var crew = crewRepository.Get(crewDTO.Id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {crewDTO.Id} not found");

            if (crewDTO.PilotId > 0)
                crew.PilotId = crewDTO.PilotId;

            crewRepository.Update( );
        }

        public void DeleteAllEntities()
        {
            crewRepository.DeleteAll();
        }

        public void DeleteEntity(int id)
        {
            var crew = crewRepository.Get(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            crewRepository.Delete(crew);
        }
    }
}
