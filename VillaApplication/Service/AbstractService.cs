
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VillaApplication.Configuration;
using VillaApplication.Mapper.Base;
using VillaApplication.Model.Base;

namespace VillaApplication.Service
{
    public abstract class AbstractService<E, DTO, BO, MBO, MDTO>(ApplicationDbContext _applicationDbContext, ILogger _logger, DbSet<E> _repository)
        where E : Entity 
        where DTO : EntityDTO 
        where BO : EntityBO
        where MBO : BaseMapperEToBO<E, BO>, new()
        where MDTO : BaseMapperEtoDTO<E, DTO>, new()
    {
        protected readonly ILogger logger = _logger;
        protected readonly ApplicationDbContext db = _applicationDbContext;
        public required DbSet<E> repository = _repository;
        protected readonly BaseMapperEToBO<E, BO> mapperEToBO = new MBO();
        protected readonly BaseMapperEtoDTO<E, DTO> mapperEToDTO = new MDTO();

        protected string GetClass()
        {
           return  repository.EntityType.ClrType.Name;
        }

        protected void Save()
        {
            db.SaveChanges();
        }

        protected E Save(BO bo)
        {
            DateTime now = DateTime.Now;

            bo.CreatedDate = now;
            bo.EditedDate = now;

            return Save(mapperEToBO.MapEXToE(bo));    
        }

        protected E Save(E entity) 
        {
            EntityEntry<E> entityEntry = repository.Add(entity);
            Save();
            return entityEntry.Entity;
        }

        protected E? GetById(int id)
        {
            E? e = repository.Find(id);

            logger.LogInformation("Get entity {EntityType} with id: {Id}", GetClass(), id);

            if (e == null)
            {
                logger.LogError("Not found {EntityType} with id: {Id}.", GetClass(), id);
                return null;
            }
            else
            {
                logger.LogError("Found {EntityType} with id: {Id}.", GetClass(), id);
                return e;
            }
        }

        protected bool Delete(E entity)
        {
            logger.LogInformation("Delete entity {EntityType} with id: {Id}", entity.GetType().Name, entity.Id);

            E entityEntry = repository.Remove(entity).Entity;
            Save();

            logger.LogInformation("Deleted entity {EntityType} with id: {Id}", entity.GetType().Name, entity.Id);

            return entityEntry != null;
        }
    }
}
