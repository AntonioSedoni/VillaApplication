using Microsoft.AspNetCore.Mvc;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Dto;
using VillaApplication.Service;

namespace VillaApplication.Controller
{
    [Route("/api/villa")]
    [ApiController]
    public class VillaController(IVillaService service, ILogger<VillaController> logger) : ControllerBase
    {
        private readonly IVillaService service = service;
        private readonly ILogger logger = logger;

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(service.GetAllEntities());   
        }

        [HttpGet("{id:int}")]
        public ActionResult<VillaDTO> GetVillas(int id)
        {
            VillaDTO? villaDTO = service.GetById(id);

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
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaBO bo)
        {
            return Ok(service.AddVilla(bo));
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteVilla(int id)
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
        public ActionResult<VillaDTO> EditVilla(int id, [FromBody] VillaBO bo)
        {
            if(id == 0 || bo == null)
            {
                logger.LogError("Error to edit Vila.");
                return BadRequest();
            }

            VillaDTO? dto = service.Edit(id, bo);

            if (dto == null) {
                return BadRequest();
            }
            else {
                return Ok(dto);
            }
        }
    }
}
