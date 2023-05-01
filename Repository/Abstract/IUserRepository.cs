using PvDriver.Base;
using PvDriver.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Repository.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
