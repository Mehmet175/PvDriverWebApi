using PvDriver.Base;
using PvDriver.Ef;
using PvDriver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PvDriver.Repository.Abstract
{
    public interface IDeviceRepository : IEntityRepository<Device>
    {
        public BaseModel<IEnumerable<DeviceModel>> CtGetList(Expression<Func<Device, bool>> filterl);
    }
}
