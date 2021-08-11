using System;
using System.ComponentModel.DataAnnotations;
using BackendCore.Common.Core;
using BackendCore.Entities;

namespace BackendCore.Common.DTO.Device
{
    public class AddDeviceDto : IEntityDto<long?>
    {
        public long? Id { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public Status Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
