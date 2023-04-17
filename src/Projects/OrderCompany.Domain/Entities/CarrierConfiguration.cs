using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderCompany.Persistence.Entities;

namespace OrderCompany.Domain.Entities
{
    public class CarrierConfiguration : Entity
    {
        public int CarrierId{ get; set; }
        public int CarrierMaxDesi{ get; set; }
        public int CarrierMinDesi{ get; set; }
        public decimal CarrierCost{ get; set; }
    }
}
