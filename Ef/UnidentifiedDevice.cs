using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class UnidentifiedDevice
    {
        public int Id { get; set; }
        public string DeviceSerialNo { get; set; }
        public string PackageType { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool? Status { get; set; }
    }
}
