using BackendCore.Entities.Entities.Base;

namespace BackendCore.Entities.Entities
{
    public class Device : BaseEntity<long>
    {
        public string Vendor { get; set; }
        public Status Status { get; set; }
        public long GatewayId { get; set; }
        public virtual Gateway Gateway { get; set; }
    }
}