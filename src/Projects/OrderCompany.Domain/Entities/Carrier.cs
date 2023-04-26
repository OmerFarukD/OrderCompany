using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderCompany.Persistence.Entities;

namespace OrderCompany.Domain.Entities
{
    public class Carrier : Entity
    {
        public string? CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost{ get; set; }
        public int CarrierConfigurationId{ get; set; }

        public virtual CarrierConfiguration? CarrierConfiguration{ get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        public virtual CarrierReport? CarrierReport { get; set; }

    }
}
