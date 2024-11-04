using VillaApplication.Model.Base;

namespace VillaApplication.Mapper.Base
{
    public abstract class BaseMapperEToBO<E, BO> : Mapper<E, BO>
        where E : Entity
        where BO : EntityBO
    {
    }
}
