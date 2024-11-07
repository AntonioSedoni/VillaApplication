using Microsoft.EntityFrameworkCore.ChangeTracking;
using VillaApplication.Database;
using VillaApplication.Mapper.Base;
using VillaApplication.Model.Base;

namespace VillaApplication.Service
{
    public abstract class AbstractService<E, DTO, BO, MBO, MDTO>(ApplicationDbContext _applicationDbContext, ILogger _logger)
        where E : Entity 
        where DTO : EntityDTO 
        where BO : EntityBO
        where MBO : BaseMapperEToBO<E, BO>, new()
        where MDTO : BaseMapperEtoDTO<E, DTO>, new()
    {
        protected readonly ILogger logger = _logger;
        protected readonly ApplicationDbContext db = _applicationDbContext;
        protected readonly BaseMapperEToBO<E, BO> mapperEToBO = new MBO();
        protected readonly BaseMapperEtoDTO<E, DTO> mapperEToDTO = new MDTO();

        protected abstract string GetClass();

        protected DTO Save(BO bo)
        {
            DateTime now = DateTime.Now;

            bo.CreatedDate = now;
            bo.EditedDate = now;

            return Save(mapperEToBO.MapBOToE(bo));    
        }

        protected DTO Save(E entity) 
        {
            EntityEntry<E> entityEntry = db.Add<E>(entity);
            db.SaveChanges();

            return mapperEToDTO.MapEToDTO(entityEntry.Entity);
        }

        protected E? Update(int id, BO bo)
        {
            logger.LogInformation("Updated entity: {Entity} with id: {Id}.", GetClass(), id);

            E? entity = GetById(id);

            if (entity == null)
            {
                logger.LogError("Entity: {Entity} with id: {Id} not found.", GetClass(), id);

                return null;
            }

            if (bo == null)
            {
                logger.LogError("The request entity is null.");

                return null;
            }

            E entityToUpdate = mapperEToBO.MapBOToE(bo);
            entityToUpdate.Id = id;
            entityToUpdate.EditedDate = DateTime.UtcNow;

            E entityUpdated = db.Update<E>(entityToUpdate).Entity;
            db.SaveChanges();

            logger.LogInformation("Updated entity: {Entity} with id: {Id}.", GetClass(), id);

            return entityUpdated;
        }

        protected E? GetById(int id)
        {
            E? e = db.Find<E>(id);

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

            E entityEntry = db.Remove<E>(entity).Entity;
            db.SaveChanges();

            logger.LogInformation("Deleted entity {EntityType} with id: {Id}", entity.GetType().Name, entity.Id);

            return entityEntry != null;
        }
    }
}
