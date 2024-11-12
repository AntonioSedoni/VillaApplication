using VillaApplication.Database;
using VillaApplication.Mapper;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service.Impl
{
    public class OwnerService(ApplicationDbContext _applicationDbContext, ILogger<OwnerService> _logger) :
        AbstractService<Owner, OwnerDTO, OwnerBO, OwnerMapperEToBO, OwnerMapperEToDTO>(_applicationDbContext, _logger),
        IOwnerService
    {
        protected override string GetClass()
        {
            return typeof(Owner).Name;
        }

        public OwnerDTO? AddOwner(OwnerBO bo)
        {
            if (bo == null)
            {
                logger.LogError("Error to create Owner. The body is empty.");
                return null;
            }

            OwnerDTO dto = Save(bo);

            logger.LogInformation("Created new Owner with id: {Id}.", dto.Id);

            return dto;
        }

        public bool Delete(int id)
        {
            bool isDeleted = base.Delete(id);

            if (isDeleted)
            {
                logger.LogInformation("The entity {Entity} with id: {Id} is deleted.", GetClass(), id);
            }
            else
            {
                logger.LogInformation("the entity {Entity} with id: {Id} didn't delete.", GetClass(), id);
            }

            return isDeleted;
        }

        public OwnerDTO? Edit(int id, OwnerBO bo)
        {
            Owner? owner = Update(id, bo);

            return owner != null ? mapperEToDTO.MapEToDTO(owner) : null;
        }

        public List<OwnerDTO> GetAllEntities()
        {
            return mapperEToDTO.MapEToDTO(db.Owners.ToList());
        }

        public new OwnerDTO? GetById(int id)
        {
            Owner? e = GetEntityById(id);

            if (e == null)
            {
                return null;
            }
            else
            {
                return mapperEToDTO.MapEToDTO(e);
            }
        }

        public Owner? GetEntityById(int id)
        {
            return base.GetById(id);
        }
    }
}
