using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICrewService
    {
        CrewDTO GetEntity(int id);
        IEnumerable<CrewDTO> GetEntities();
        void CreateEntity(CrewDTO entity);
        void UpdateEntity(int id, CrewDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
