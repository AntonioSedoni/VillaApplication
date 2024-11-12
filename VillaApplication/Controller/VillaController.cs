using Microsoft.AspNetCore.Mvc;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
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
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse(400, $"Id: {id} not valid."));
            }

            VillaDTO? villaDTO = service.GetById(id);

            if (villaDTO == null)
            {
                logger.LogError("Error to get Villa entity. Villa with id {Id} not found.", id);

                return NotFound(new ErrorResponse(404, $"Villa with id: {id} not found."));
            }
            else
            {
                return villaDTO;
            }
        }

        [HttpPost]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaBO bo)
        {
            VillaDTO? villaDTO = service.AddVilla(bo);

            if (villaDTO == null)
            {
                logger.LogError("Error to create new Villa entity. Owner with id {Id} not found.", bo.OwnerId);

                return NotFound(new ErrorResponse(404, $"Owner with id: {bo.OwnerId} not found."));
            }

            return Ok(villaDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteVilla(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse(400, $"Id: {id} not valid."));
            }

            bool deleted = service.Delete(id);

            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new ErrorResponse(404, $"Villa with id: {id} not found."));
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
