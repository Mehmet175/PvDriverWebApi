using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class ShortMode
    {
        public int Id { get; set; }
        public Guid? DeviceId { get; set; }
        public int? WorkTime { get; set; }
        public int? StopTime { get; set; }
    }
}
