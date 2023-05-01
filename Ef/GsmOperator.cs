using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class GsmOperator
    {
        public GsmOperator()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
