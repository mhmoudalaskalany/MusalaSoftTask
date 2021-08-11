using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BackendCore.Entities.Entities.Base;

namespace BackendCore.Entities.Entities
{
    public class Gateway : BaseEntity<long>
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public virtual ICollection<Device> Devices { get; set; } = new Collection<Device>();
    }
}
