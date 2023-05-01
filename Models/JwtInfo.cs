using PvDriver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class JwtInfo
    {
        public Guid? UserId { get; set; }
        public RolEnum RolId { get; set; }
        public string UserName { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
