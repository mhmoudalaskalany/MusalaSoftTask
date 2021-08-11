using System.Collections.Generic;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Device;

namespace BackendCore.Common.DTO.Gateway
{
    public class GatewayDto : IEntityDto<long?>
    {
        public long? Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public List<DeviceDto> Devices { get; set; } = new List<DeviceDto>();
    }
}
