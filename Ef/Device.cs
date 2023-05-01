using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class Device
    {
        public Device()
        {
            DeviceAddresses = new HashSet<DeviceAddress>();
            DeviceParameters = new HashSet<DeviceParameter>();
            DeviceUsers = new HashSet<DeviceUser>();
            ReportLogs = new HashSet<ReportLog>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string SerialNo { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? CompanyId { get; set; }
        public int? ModelTypeId { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        public string GsmNo { get; set; }
        public DateTime GsmFinishDate { get; set; }
        public DateTime InstallationDate { get; set; }
        public int? InstallationCity { get; set; }
        public string DeviceKw { get; set; }
        public DateTime CardWarrantyExpiryDate { get; set; }
        public int? GsmOperatorId { get; set; }
        public bool? IsTimedWork { get; set; }
        public bool? IsShortMode { get; set; }
        public bool? LastWorkingStatus { get; set; }
        public DateTime? LastWorkingStatusDateTime { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Address6 { get; set; }
        public string Address7 { get; set; }
        public int InstallationDistrict { get; set; }
        public string MotorkW { get; set; }
        public DateTime DeviceWarranty { get; set; }

        public virtual Company Company { get; set; }
        public virtual GsmOperator GsmOperator { get; set; }
        public virtual ModelType ModelType { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual ICollection<DeviceAddress> DeviceAddresses { get; set; }
        public virtual ICollection<DeviceParameter> DeviceParameters { get; set; }
        public virtual ICollection<DeviceUser> DeviceUsers { get; set; }
        public virtual ICollection<ReportLog> ReportLogs { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
