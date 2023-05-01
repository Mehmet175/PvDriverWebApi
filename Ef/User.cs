using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class User
    {
        public User()
        {
            DeviceUsers = new HashSet<DeviceUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid? CompanyId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }
        public bool? Status { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<DeviceUser> DeviceUsers { get; set; }
    }
}
