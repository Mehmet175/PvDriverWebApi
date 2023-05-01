using PvDriver.Base;
using PvDriver.Ef;
using PvDriver.Models;
using PvDriver.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PvDriver.Repository.Concrete
{
    public class DeviceRepository : EfEntityRepositoryBase<Device>, IDeviceRepository
    {
        DRIVERSContext context = new DRIVERSContext();

        public BaseModel<IEnumerable<DeviceModel>> CtGetList(Expression<Func<Device, bool>> filterl)
        {
            try
            {
                var result = (from device in context.Devices
                                  // Package Type Join
                              join packagetype in context.PackageTypes
                              on device.PackageTypeId equals packagetype.Id
                              // Company Join
                              join company in context.Companies
                              on device.CompanyId equals company.Id
                              // Model Type Join
                              join modelType in context.ModelTypes
                              on device.ModelTypeId equals modelType.Id
                              // Installation City (City) join
                              join city in context.Cities
                              on device.InstallationCity equals city.Id
                              // GsmOperator join
                              join gsmOperator in context.GsmOperators
                              on device.GsmOperatorId equals gsmOperator.Id
                              // Installation District (district) join
                              join district in context.Districts
                              on device.InstallationDistrict equals district.Id
                              select new DeviceModel()
                              {
                                  Id = device.Id,
                                  SerialNo = device.SerialNo,
                                  PackageTypeId = device.PackageTypeId,
                                  PackageType = new PackageTypeModel()
                                  {
                                      Id = packagetype.Id,
                                      Name = packagetype.Name,
                                      Status = packagetype.Status,
                                      Value = packagetype.Value,
                                  },
                                  CompanyId = device.CompanyId,
                                  Company = new CompanyModel()
                                  {
                                      Id = company.Id,
                                      Name = company.Name,
                                      TopCompany = company.TopCompany,
                                      Status = company.Status,
                                  },
                                  ModelTypeId = device.ModelTypeId,
                                  ModelType = new ModelTypeModel()
                                  {
                                      Id = modelType.Id,
                                      Name = modelType.Name,
                                      Value = modelType.Value,
                                      Status = modelType.Status,
                                      Address1 = modelType.Address1,
                                      Address2 = modelType.Address2,
                                      Address3 = modelType.Address3,
                                      Address4 = modelType.Address4,
                                      Address5 = modelType.Address5,
                                      Address6 = modelType.Address6,
                                      Address7 = modelType.Address7,
                                      Dividing1 = modelType.Dividing1,
                                      Dividing2 = modelType.Dividing2,
                                      Dividing3 = modelType.Dividing3,
                                      Dividing4 = modelType.Dividing4,
                                      Dividing5 = modelType.Dividing5,
                                      Dividing6 = modelType.Dividing6,
                                      Dividing7 = modelType.Dividing7,
                                      Logo = modelType.Logo,
                                  },
                                  Status = device.Status,
                                  Name = device.Name,
                                  GsmNo = device.GsmNo,
                                  GsmFinishDate = device.GsmFinishDate,
                                  InstallationDate = device.InstallationDate,
                                  InstallationCityId = device.InstallationCity,
                                  InstallationCity = new CityModel()
                                  {
                                      Id = city.Id,
                                      Name = city.Name,
                                      Code = city.Code,
                                  },
                                  DeviceKw = device.DeviceKw,
                                  CardWarrantyExpiryDate = device.CardWarrantyExpiryDate,
                                  GsmOperatorId = device.GsmOperatorId,
                                  GsmOperator = new GsmOperatorModel()
                                  {
                                      Id = gsmOperator.Id,
                                      Name = gsmOperator.Name,
                                      Status = gsmOperator.Status,
                                  },
                                  IsTimedWork = device.IsTimedWork,
                                  IsShortMode = device.IsShortMode,
                                  LastWorkingStatus = device.LastWorkingStatus,
                                  LastWorkingStatusDateTime = device.LastWorkingStatusDateTime,
                                  Address1 = device.Address1,
                                  Address2 = device.Address2,
                                  Address3 = device.Address3,
                                  Address4 = device.Address4,
                                  Address5 = device.Address5,
                                  Address6 = device.Address6,
                                  Address7 = device.Address7,
                                  InstallationDistrictId = device.InstallationDistrict,
                                  InstallationDistrict = new DistrictModel()
                                  {
                                      ID = district.Id,
                                      CityID = district.CityId,
                                      Name = district.Name,
                                      Status = district.Status,
                                  },
                                  MotorkW = device.MotorkW,
                                  DeviceWarranty = device.DeviceWarranty,
                              });

                return new BaseModel<IEnumerable<DeviceModel>>()
                {
                    Status = StatusEnum.success,
                    Data = result,
                };
            }
            catch (Exception e)
            {
                return new BaseModel<IEnumerable<DeviceModel>>()
                {
                    Message = e.Message,
                    Status = StatusEnum.error,
                };
            }
        }
    }
}
