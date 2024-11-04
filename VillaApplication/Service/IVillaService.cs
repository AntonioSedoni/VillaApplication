using VillaApplication.Model.Bo;
using VillaApplication.Model.Data;
using VillaApplication.Model.Dto;

namespace VillaApplication.Service
{
    public interface IVillaService
    {
        public VillaDTO? AddVilla(VillaBO bo);
        public VillaDTO? GetById(int id);
        public List<VillaDTO> GetAllEntities();
        public bool Delete(int id);
        public VillaDTO? Edit(int id, VillaBO bo);
    }
}
