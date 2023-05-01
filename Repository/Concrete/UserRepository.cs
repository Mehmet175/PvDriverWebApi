using PvDriver.Base;
using PvDriver.Ef;
using PvDriver.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Repository.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
    }
}
