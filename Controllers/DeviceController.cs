using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PvDriver.Ef;
using PvDriver.Models;
using PvDriver.Repository.Abstract;
using PvDriver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private IDeviceRepository _deviceRepository;
        private IDeviceUserRepository _deviceUserRepository;

        public DeviceController(IDeviceRepository deviceRepository, IDeviceUserRepository deviceUserRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceUserRepository = deviceUserRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var jwtInfo = JwtUtil.GetUserInfo(HttpContext.Request);
                switch (jwtInfo.RolId)
                {
                    // Adminse tüm cihazlar dönüyor
                    case RolEnum.Admin:
                        {
                            var result = _deviceRepository.CtGetList(m => true);
                            if (result.IsError())
                            {
                                return BadRequest(result.Message);
                            }
                            return Ok(result.Data);
                        }
                    // Bayiyse altındaki cihazlar dönüyor
                    case RolEnum.Dealer:
                        {
                            var result = _deviceRepository.CtGetList(m => m.CompanyId == jwtInfo.CompanyId);
                            if (result.IsError())
                            {
                                return BadRequest(result.Message);
                            }
                            return Ok(result.Data);
                        }
                    // Tekil kullanıcıysa DeviceUser
                    case RolEnum.Single:
                        {
                            var deviceUserList = _deviceUserRepository.GetList(m => m.UserId == jwtInfo.UserId);
                            if (deviceUserList.IsError())
                            {
                                return BadRequest(deviceUserList.Message);
                            }
                            var deviceList = _deviceRepository.CtGetList(m => deviceUserList.Data.Any(a => a.DeviceId == m.Id));
                            if (deviceList.IsError())
                            {
                                return BadRequest(deviceList.Message);
                            }
                            return Ok(deviceUserList.Data);
                        }
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _deviceRepository.CtGetList(m => m.Id == id);
            if (result.IsError())
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Add(DeviceModel deviceModel)
        {
            try
            {
                var result = _deviceRepository.Add(new Device()
                {
                    Id = Guid.NewGuid(),
                    SerialNo = deviceModel.SerialNo,
                    PackageTypeId = deviceModel.PackageTypeId,
                    CompanyId = deviceModel.CompanyId,
                    ModelTypeId = deviceModel.ModelTypeId,
                    Status = true,
                    Name = deviceModel.Name,
                    GsmNo = deviceModel.GsmNo,
                    GsmFinishDate = deviceModel.GsmFinishDate,
                    InstallationDate = deviceModel.InstallationDate,
                    InstallationCity = deviceModel.InstallationCityId,
                    DeviceKw = deviceModel.DeviceKw,
                    CardWarrantyExpiryDate = deviceModel.CardWarrantyExpiryDate,
                    GsmOperatorId = deviceModel.GsmOperatorId,
                    IsTimedWork = false,
                    IsShortMode = false,
                    LastWorkingStatus = false,
                    LastWorkingStatusDateTime = deviceModel.LastWorkingStatusDateTime,
                    Address1 = deviceModel.Address1,
                    Address2 = deviceModel.Address2,
                    Address3 = deviceModel.Address3,
                    Address4 = deviceModel.Address4,
                    Address5 = deviceModel.Address5,
                    Address6 = deviceModel.Address6,
                    Address7 = deviceModel.Address7,
                    InstallationDistrict = deviceModel.InstallationDistrictId,
                    MotorkW = deviceModel.MotorkW,
                    DeviceWarranty = deviceModel.DeviceWarranty,
                });
                if (result.IsError())
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var dataToBeDelete = _deviceRepository.Get(m => m.Id == id);
                if (dataToBeDelete.IsError())
                {
                    return BadRequest(dataToBeDelete.Message);
                }
                if (dataToBeDelete.IsEmpty())
                {
                    return BadRequest("Cihaz bulunamadı!");
                }
                var deleteResult = _deviceRepository.Delete(dataToBeDelete.Data);
                if (deleteResult.IsError())
                {
                    return BadRequest();
                }
                return Ok(deleteResult.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
