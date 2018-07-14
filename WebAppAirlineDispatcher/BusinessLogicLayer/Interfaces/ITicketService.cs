using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        TicketDTO GetEntity(int id);
        IEnumerable<TicketDTO> GetEntities();
        void CreateEntity(TicketDTO entity);
        void UpdateEntity(int id, TicketDTO entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
