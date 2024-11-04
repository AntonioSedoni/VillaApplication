using Microsoft.AspNetCore.Mvc;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Dto;
using VillaApplication.Service;

namespace OwnerApplication.Controller
{
    [Route("/api/owner")]
    [ApiController]
    public class OwnerController(IOwnerService service, ILogger<OwnerController> logger) : ControllerBase
    {
        private readonly IOwnerService service = service;
        private readonly ILogger logger = logger;

        [HttpGet]
        public ActionResult<IEnumerable<OwnerDTO>> GetOwners()
        {
            return Ok(service.GetAllEntities());
        }

        [HttpGet("{id:int}")]
        public ActionResult<OwnerDTO> GetOwners(int id)
        {
            OwnerDTO? villaDTO = service.GetById(id);

            if (villaDTO == null)
            {
                return NotFound();
            }
            else
            {
                return villaDTO;
            }
        }

        [HttpPost]
        public ActionResult<OwnerDTO> CreateOwner([FromBody] OwnerBO bo)
        {
            return Ok(service.AddOwner(bo));
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteOwner(int id)
        {
            bool deleted = service.Delete(id);

            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<OwnerDTO> EditOwner(int id, [FromBody] OwnerBO bo)
        {
            if (id == 0 || bo == null)
            {
                logger.LogError("Error to edit Vila.");
                return BadRequest();
            }

            OwnerDTO? dto = service.Edit(id, bo);

            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(dto);
            }
        }
    }
}
