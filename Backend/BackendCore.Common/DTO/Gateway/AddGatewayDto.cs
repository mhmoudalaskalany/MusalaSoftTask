using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Device;

namespace BackendCore.Common.DTO.Gateway
{
    public class AddGatewayDto : IEntityDto<long?>
    {
        public long? Id { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ip { get; set; }
        public List<AddDeviceDto> Devices { get; set; }
    }
}
