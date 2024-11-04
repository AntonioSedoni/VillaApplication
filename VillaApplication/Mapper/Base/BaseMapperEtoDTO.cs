using VillaApplication.Model.Base;

namespace VillaApplication.Mapper.Base
{
    public class BaseMapperEtoDTO<E, DTO> : Mapper<E, DTO>
        where E : Entity
        where DTO : EntityDTO
    {
    }
}
