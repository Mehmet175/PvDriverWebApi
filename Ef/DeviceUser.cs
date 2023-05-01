using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class DeviceUser
    {
        public int Id { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid? UserId { get; set; }
        public bool? Status { get; set; }

        public virtual Device Device { get; set; }
        public virtual User User { get; set; }
    }
}
