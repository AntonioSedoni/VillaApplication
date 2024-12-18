﻿using VillaApplication.Database;
using VillaApplication.Mapper;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service.Impl
{
    public class VillaService(ApplicationDbContext _applicationDbContext, ILogger<VillaService> _logger, IOwnerService _ownerService) :
        AbstractService<Villa, VillaDTO, VillaBO, VillaMapperEToBO, VillaMapperEToDTO>(_applicationDbContext, _logger),
        IVillaService
    {
        private readonly IOwnerService OwnerService = _ownerService;

        protected override string GetClass()
        {
            return typeof(Villa).Name;
        }

        public VillaDTO? AddVilla(VillaBO bo)
        {

            Owner? owner = OwnerService.GetEntityById(bo.OwnerId);

            if (owner == null)
            {
                logger.LogError("Error to create Villa. Owner with id: {Id} not found.", bo.OwnerId);
                return null;
            }

            VillaDTO dto = Save(bo);

            logger.LogInformation("Created new Villa with id: {Id}.", dto.Id);

            return dto;
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
                return mapperEToDTO.MapEToDTO(e);
            }
        }

        public List<VillaDTO> GetAllEntities()
        {
            logger.LogInformation("Get all Villas.");

            List<Villa> villas = db.Villas.ToList();

            return mapperEToDTO.MapEToDTO(villas);
        }

        public bool Delete(int id)
        {
            bool isDeleted = Delete(id);

            if (isDeleted)
            {
                logger.LogInformation("The entity with id: {Id} is deleted.", id);
            }
            else
            {
                logger.LogInformation("the entity with id: {Id} didn't delete.", id);
            }

            return isDeleted;
        }

        public VillaDTO? Edit(int id, VillaBO bo)
        {
            Villa? villa = Update(id, bo);

            return villa != null ? mapperEToDTO.MapEToDTO(villa) : null;
        }
    }
}
