using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        ITicketService ticketService;

        public TicketsController(ITicketService serv)
        {
            ticketService = serv;
        }

        // GET: api/tickets
        public IActionResult Get()
        {
            return Ok(ticketService.GetEntities());
        }

        // GET api/tickets/5
        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = ticketService.GetEntity(id);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ticketService.CreateEntity(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(ticketDTO);
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketDTO ticketDTO)
        {
            ticketDTO.Id = id;

            try
            {
                ticketService.UpdateEntity(id,ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(ticketService.GetEntity(id));
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ticketService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/tickets
        [HttpDelete]
        public IActionResult Delete()
        {
            ticketService.DeleteAllEntities();
            return NoContent();
        }
    }
}