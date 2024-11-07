using AutoMapper;
using VillaApplication.Model.Base;

namespace VillaApplication.Mapper.Base
{
    public abstract class BaseMapperEtoDTO<E, DTO> : Profile
        where E : Entity
        where DTO : EntityDTO
    {
        private readonly IMapper mapper;

        public BaseMapperEtoDTO()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, DTO>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public DTO MapEToDTO(E e)
        {
            return mapper.Map<DTO>(e);
        }

        public List<DTO> MapEToDTO(List<E> entities)
        {
            return mapper.Map<List<DTO>>(entities);
        }
    }
}
