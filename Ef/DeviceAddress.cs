using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class DeviceAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid? DeviceId { get; set; }
        public bool? Status { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsWrite { get; set; }
        public bool? IsSend { get; set; }
        public bool? Get { get; set; }
        public bool? Set { get; set; }
        public string LastValue { get; set; }
        public string SendValue { get; set; }
        public DateTime ProcessingTime { get; set; }

        public virtual Device Device { get; set; }
    }
}
