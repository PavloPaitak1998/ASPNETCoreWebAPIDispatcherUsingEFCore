using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartureService
    {
        DepartureDTO GetEntity(int id);
        IEnumerable<DepartureDTO> GetEntities();
        void CreateEntity(DepartureDTO entity);
        void UpdateEntity(int id, DepartureDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
