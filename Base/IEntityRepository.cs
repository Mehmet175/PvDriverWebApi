using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PvDriver.Base
{
    public interface IEntityRepository<T> : IDisposable
    {
        public BaseModel<IEnumerable<T>> GetAll();
        public BaseModel<T> Get(Expression<Func<T, bool>> filterl);
        public BaseModel<IEnumerable<T>> GetList(Expression<Func<T, bool>> filterl);
        public BaseModel<T> Add(T data);
        public BaseModel<T> Update(T data);
        public BaseModel<T> Delete(T data);

    }
}
