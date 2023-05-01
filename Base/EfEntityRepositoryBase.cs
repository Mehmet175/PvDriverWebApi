using PvDriver.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PvDriver.Base
{
    public abstract class EfEntityRepositoryBase<TEntity>
       : IEntityRepository<TEntity>
       where TEntity : class, new()
    {

        DRIVERSContext context;

        public EfEntityRepositoryBase()
        {
            context = new DRIVERSContext();
        }

        public BaseModel<TEntity> Add(TEntity data)
        {
            try
            {
                var result = context.Set<TEntity>().Add(data);
                context.SaveChanges();
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }

        public BaseModel<TEntity> Delete(TEntity data)
        {

            try
            {
                var result = context.Set<TEntity>().Remove(data);
                context.SaveChanges();
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }

        public void Dispose()
        {

        }

        public BaseModel<TEntity> Get(Expression<Func<TEntity, bool>> filterl)
        {
            try
            {
                var data = context.Set<TEntity>().FirstOrDefault(filterl);
                return new BaseModel<TEntity>()
                {
                    Status = data == null ? StatusEnum.empty : StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }

        public BaseModel<IEnumerable<TEntity>> GetAll()
        {

            try
            {
                var data = context.Set<TEntity>();
                return new BaseModel<IEnumerable<TEntity>>()
                {
                    Status = data == null ? StatusEnum.empty : StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<IEnumerable<TEntity>>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }

        public BaseModel<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> filterl)
        {

            try
            {
                var data = context.Set<TEntity>().Where(filterl);
                return new BaseModel<IEnumerable<TEntity>>()
                {
                    Status = data == null ? StatusEnum.empty : StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<IEnumerable<TEntity>>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }

        public BaseModel<TEntity> Update(TEntity data)
        {
            try
            {
                var result = context.Set<TEntity>().Update(data);
                context.SaveChanges();
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.success,
                    Message = null,
                    Data = data,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<TEntity>()
                {
                    Status = StatusEnum.error,
                    Message = e.Message,
                    Data = null,
                };
            }
        }
    }
}
