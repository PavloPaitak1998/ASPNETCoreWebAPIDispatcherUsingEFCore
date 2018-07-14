using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPilotService
    {
        PilotDTO GetEntity(int id);
        IEnumerable<PilotDTO> GetEntities();
        void CreateEntity(PilotDTO entity);
        void UpdateEntity(int id, PilotDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
