using AutoMapper;
using VillaApplication.Mapper;
using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service.Impl
{
    public class OwnerService(ApplicationDbContext _applicationDbContext, ILogger<OwnerService> _logger) :
        AbstractService<Owner, OwnerDTO, OwnerBO, OwnerMapperEToBO, OwnerMapperEToDTO>(_applicationDbContext, _logger, _applicationDbContext.Owners),
        IOwnerService
    {
        public OwnerDTO? AddOwner(OwnerBO bo)
        {
            if (bo == null)
            {
                logger.LogError("Error to create Owner. The body is empty.");
                return null;
            }

            Owner e = Save(bo);

            logger.LogInformation("Created new Owner with id: {}.", e.Id);

            return new OwnerDTO() { FristName = bo.FristName, LastName = e.LastName, Id = e.Id };
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OwnerDTO? Edit(int id, OwnerBO bo)
        {
            throw new NotImplementedException();
        }

        public List<OwnerDTO> GetAllEntities()
        {
            throw new NotImplementedException();
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
                return new OwnerDTO() { Id = e.Id, FristName = e.FristName, LastName = e.LastName };
            }
        }

        public Owner? GetEntityById(int id)
        {
            return base.GetById(id);
        }
    }
}
