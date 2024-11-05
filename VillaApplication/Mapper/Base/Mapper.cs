using AutoMapper;

namespace VillaApplication.Mapper.Base
{
    public abstract class Mapper<E, EX> : Profile
    {
        private readonly IMapper mapper;

        public Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, EX>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public E MapEXToE(EX bo)
        {
            return mapper.Map<E>(bo);
        }

        public List<E> MapEXToE(List<EX> bos)
        {
            return mapper.Map<List<E>>(bos);
        }

        public EX MapEToEX(E e)
        {
            return mapper.Map<EX>(e);
        }

        public List<EX> MapEToEX(List<E> entities)
        {
            return mapper.Map<List<EX>>(entities);
        }
    }
}
