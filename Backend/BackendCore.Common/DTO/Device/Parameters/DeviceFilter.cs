using BackendCore.Common.DTO.Base;

namespace BackendCore.Common.DTO.Device.Parameters
{
    public class DeviceFilter : MainFilter
    {
        public long Id { get; set; }
        public string GatewayName { get; set; }
        public string Vendor { get; set; }
    }
}
