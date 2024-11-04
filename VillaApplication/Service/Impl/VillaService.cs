using AutoMapper;
using VillaApplication.Mapper;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service.Impl
{
    public class VillaService(ApplicationDbContext _applicationDbContext, ILogger<VillaService> _logger, IOwnerService _ownerService) :
        AbstractService<Villa, VillaDTO, VillaBO, VillaMapperEToBO, VillaMapperEToDTO>(_applicationDbContext, _logger, _applicationDbContext.Villas),
        IVillaService
    {
        private readonly IOwnerService OwnerService = _ownerService;

        public VillaDTO? AddVilla(VillaBO bo)
        {
            if (bo == null)
            {
                logger.LogError("Error to create Villa. The body is empty.");
                return null;
            }

            DateTime now = DateTime.Now;

            Owner? owner = OwnerService.GetEntityById(bo.OwnerId);

            if (owner == null)
            {
                return null;
            }

            Villa e = Save(bo);

            logger.LogInformation("Created new Villa with id: {}.", e.Id);

            return new VillaDTO() { Name = bo.Name, Id = e.Id, OwnerId = e.OwnerId };
        }

        public new VillaDTO? GetById(int id)
        {
            Villa? e = base.GetById(id);

            if (e == null)
            {
                return null;
            }
            else
            {
                return mapperEToDTO.MapEToEX(e);
            }
        }

        public List<VillaDTO> GetAllEntities()
        {
            logger.LogInformation("Get all Villas.");

            List<Villa> villas = repository.ToList();

            return mapperEToDTO.MapEToEX(villas);
        }

        public bool Delete(int id)
        {
            Villa? villa = base.GetById(id);

            if (villa == null)
            {
                logger.LogError("Error to delete Villa with id: {}.", id);
                return false;
            }

            bool isDeleted = Delete(villa);

            if (isDeleted)
            {
                logger.LogInformation("The entity with id: {} is deleted.", id);
            }
            else
            {
                logger.LogInformation("the entity with id: {} didn't delete.", id);
            }

            return isDeleted;
        }

        public VillaDTO? Edit(int id, VillaBO bo)
        {
            Villa? villa = base.GetById(id);

            if (villa == null)
            {
                return null;
            }

            if (bo == null)
            {
                return null;
            }


            villa.Name = bo.Name;
            villa.OwnerId = bo.OwnerId;
            villa.EditedDate = DateTime.Now;

            Villa entity = repository.Update(villa).Entity;
            Save();

            logger.LogInformation("Updated entity with id: {}.", id);

            return new VillaDTO() { Id = entity.Id, Name = entity.Name };
        }
    }
}
