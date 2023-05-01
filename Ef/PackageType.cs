using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class PackageType
    {
        public PackageType()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
