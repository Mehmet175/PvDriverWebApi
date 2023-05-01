using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class Company
    {
        public Company()
        {
            Devices = new HashSet<Device>();
            InverseTopCompanyNavigation = new HashSet<Company>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TopCompany { get; set; }
        public bool? Status { get; set; }

        public virtual Company TopCompanyNavigation { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Company> InverseTopCompanyNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
