using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service
{
    public interface IOwnerService
    {
        public OwnerDTO? AddOwner(OwnerBO bo);
        public OwnerDTO? GetById(int id);
        public List<OwnerDTO> GetAllEntities();
        public bool Delete(int id);
        public OwnerDTO? Edit(int id, OwnerBO bo);
        public Owner? GetEntityById(int id);
    }
}
