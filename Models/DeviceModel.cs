using PvDriver.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class DeviceModel
    {
        public Guid Id { get; set; }

        public string SerialNo { get; set; }

        public int? PackageTypeId { get; set; }
        public PackageTypeModel PackageType { get; set; }

        public Guid? CompanyId { get; set; }
        public CompanyModel Company { get; set; }

        public int? ModelTypeId { get; set; }
        public ModelTypeModel ModelType { get; set; }

        public bool? Status { get; set; }

        public string Name { get; set; }

        public string GsmNo { get; set; }

        public DateTime GsmFinishDate { get; set; }

        public DateTime InstallationDate { get; set; }

        // Veri tabanında Id'siz oluşturulmuş
        public int? InstallationCityId { get; set; }

        public CityModel InstallationCity { get; set; }

        public string DeviceKw { get; set; }

        public DateTime CardWarrantyExpiryDate { get; set; }

        public int? GsmOperatorId { get; set; }
        public GsmOperatorModel GsmOperator { get; set; }

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

        public int InstallationDistrictId { get; set; }
        public DistrictModel InstallationDistrict { get; set; }

        public string MotorkW { get; set; }

        public DateTime DeviceWarranty { get; set; }

    }
}
