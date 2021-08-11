using System;
using BackendCore.Common.Core;
using BackendCore.Entities;

namespace BackendCore.Common.DTO.Device
{
    public class DeviceDto : IEntityDto<long?>
    {
        public long? Id { get; set; }
        public string Vendor { get; set; }
        public Status Status { get; set; }
        public long GatewayId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
