using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStewardessService
    {
        StewardessDTO GetEntity(int id);
        IEnumerable<StewardessDTO> GetEntities();
        void CreateEntity(StewardessDTO entity);
        void UpdateEntity(int id, StewardessDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
