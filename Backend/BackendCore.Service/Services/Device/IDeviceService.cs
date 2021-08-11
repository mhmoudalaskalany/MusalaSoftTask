using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Device;
using BackendCore.Common.DTO.Device.Parameters;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Device
{
    public interface IDeviceService : IBaseService<Entities.Entities.Device, AddDeviceDto, DeviceDto , long, long?>
    {
        /// <summary>
        /// Get All Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<DataPaging> GetAllPagedAsync(BaseParam<DeviceFilter> filter);
    }
}