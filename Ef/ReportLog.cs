using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class ReportLog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid DeviceId { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public int Signal { get; set; }
        public int? WorkingStatus { get; set; }

        public virtual Device Device { get; set; }
    }
}
