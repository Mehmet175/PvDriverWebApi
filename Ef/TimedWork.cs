using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class TimedWork
    {
        public int Id { get; set; }
        public Guid? DeviceId { get; set; }
        public int? StartHour { get; set; }
        public int? FinishHour { get; set; }
        public int? StartMinute { get; set; }
        public int? FinishMinute { get; set; }
        public string StartDay { get; set; }
        public string FinishDay { get; set; }
    }
}
