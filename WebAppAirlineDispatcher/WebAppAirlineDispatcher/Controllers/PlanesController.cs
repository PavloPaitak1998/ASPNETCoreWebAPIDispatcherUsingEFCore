using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlanesController : Controller
    {
        IPlaneService planeService;

        public PlanesController(IPlaneService serv)
        {
            planeService = serv;
        }


        // GET: api/planes
        public IActionResult Get()
        {
            return Ok(planeService.GetEntities());
        }

        // GET api/planes/5
        [HttpGet("{id}", Name = "GetPlane")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = planeService.GetEntity(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneDTO planeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                planeService.CreateEntity(planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeDTO);
        }

        // PUT api/planes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneDTO planeDTO)
        {
            planeDTO.Id = id;

            try
            {
                planeService.UpdateEntity(id,planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeService.GetEntity(id));
        }

        // DELETE api/planes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                planeService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planes
        [HttpDelete]
        public IActionResult Delete()
        {
            planeService.DeleteAllEntities();
            return NoContent();
        }
    }
}
