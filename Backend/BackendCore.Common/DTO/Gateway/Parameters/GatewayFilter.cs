using BackendCore.Common.DTO.Base;

namespace BackendCore.Common.DTO.Gateway.Parameters
{
    public class GatewayFilter : MainFilter
    {
        public string Ip { get; set; }
        public string SerialNumber { get; set; }
    }
}
