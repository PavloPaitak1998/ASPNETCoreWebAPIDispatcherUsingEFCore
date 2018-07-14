using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneService
    {
        PlaneDTO GetEntity(int id);
        IEnumerable<PlaneDTO> GetEntities();
        void CreateEntity(PlaneDTO entity);
        void UpdateEntity(int id, PlaneDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
