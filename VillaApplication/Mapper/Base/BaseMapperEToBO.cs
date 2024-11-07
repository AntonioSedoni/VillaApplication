using AutoMapper;
using VillaApplication.Model.Base;

namespace VillaApplication.Mapper.Base
{
    public abstract class BaseMapperEToBO<E, BO> : Profile
        where E : Entity
        where BO : EntityBO
    {
        private readonly IMapper mapper;

        public BaseMapperEToBO()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, BO>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public E MapBOToE(BO bo)
        {
            return mapper.Map<E>(bo);
        }

        public List<E> MapBOToE(List<BO> bos)
        {
            return mapper.Map<List<E>>(bos);
        }
    }
}
