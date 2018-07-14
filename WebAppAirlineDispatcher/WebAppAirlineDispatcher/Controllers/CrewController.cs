using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class CrewController : Controller
    {
        ICrewService crewService;

        public CrewController(ICrewService serv)
        {
            crewService = serv;
        }


        // GET: api/crew
        public IActionResult Get()
        {
            return Ok(crewService.GetEntities());
        }

        // GET api/crew/5
        [HttpGet("{id}", Name = "GetCrew")]
        public IActionResult Get(int id)
        {
            try
            {
                var crew = crewService.GetEntity(id);
                return Ok(crew);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/crew
        [HttpPost]
        public IActionResult Post([FromBody]CrewDTO crewDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                crewService.CreateEntity(crewDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(crewDTO);
        }

        // PUT api/crew/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CrewDTO crewDTO)
        {
            crewDTO.Id = id;

            try
            {
                crewService.UpdateEntity(id,crewDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(crewService.GetEntity(id));
        }

        // DELETE api/crew/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                crewService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/crew
        [HttpDelete]
        public IActionResult Delete()
        {
            crewService.DeleteAllEntities();
            return NoContent();
        }
    }
}