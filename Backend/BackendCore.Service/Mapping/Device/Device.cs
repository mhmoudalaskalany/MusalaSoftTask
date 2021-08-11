using BackendCore.Common.DTO.Device;
using BackendCore.Entities.Entities;

// ReSharper disable once CheckNamespace
namespace BackendCore.Service.Mapping
{
    public partial class MappingService
    {
        public void MapDevice()
        {
            CreateMap<Device, DeviceDto>()
                .ReverseMap();

            CreateMap<Device, AddDeviceDto>()
                .ReverseMap();

        }
    }
}