using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlaneTypesController : Controller
    {
        IPlaneTypeService planeTypeService;

        public PlaneTypesController(IPlaneTypeService serv)
        {
            planeTypeService = serv;
        }


        // GET: api/planetypes
        public IActionResult Get()
        {
            return Ok(planeTypeService.GetEntities());
        }

        // GET api/planetypes/5
        [HttpGet("{id}", Name = "GetPlaneType")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = planeTypeService.GetEntity(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planetypes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneTypeDTO planeTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                planeTypeService.CreateEntity(planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeTypeDTO);
        }

        // PUT api/planetypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneTypeDTO planeTypeDTO)
        {
            planeTypeDTO.Id = id;

            try
            {
                planeTypeService.UpdateEntity(id,planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeTypeService.GetEntity(id));
        }

        // DELETE api/planetypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                planeTypeService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planetypes
        [HttpDelete]
        public IActionResult Delete()
        {
            planeTypeService.DeleteAllEntities();
            return NoContent();
        }
    }
}