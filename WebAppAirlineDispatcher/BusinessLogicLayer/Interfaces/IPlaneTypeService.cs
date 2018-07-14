using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneTypeService
    {
        PlaneTypeDTO GetEntity(int id);
        IEnumerable<PlaneTypeDTO> GetEntities();
        void CreateEntity(PlaneTypeDTO entity);
        void UpdateEntity(int id, PlaneTypeDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
