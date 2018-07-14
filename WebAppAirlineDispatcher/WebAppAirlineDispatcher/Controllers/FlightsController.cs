using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
       IFlightService flightService;

        public FlightsController(IFlightService serv)
        {
            flightService = serv;
        }


        // GET: api/flights
        public IActionResult Get()
        {
            return Ok(flightService.GetEntities());
        }

        // GET api/flights/5
        [HttpGet("{id}", Name = "GetFlight")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = flightService.GetEntity(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }        
        }

        // POST api/flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                flightService.CreateEntity(flightDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(flightDTO);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FlightDTO flightDTO)
        {
            flightDTO.Number = id;

            try
            {
                flightService.UpdateEntity(id,flightDTO);            
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(flightService.GetEntity(id));
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                flightService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/flights
        [HttpDelete]
        public IActionResult Delete()
        {
            flightService.DeleteAllEntities();
            return NoContent();
        }

    }
}