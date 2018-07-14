using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFlightService
    {
        FlightDTO GetEntity(int id);
        IEnumerable<FlightDTO> GetEntities();
        void CreateEntity(FlightDTO entity);
        void UpdateEntity(int id, FlightDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
