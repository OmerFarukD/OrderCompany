using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderCompany.Persistence.Entities;

namespace OrderCompany.Domain.Entities
{
    public class Order : Entity
    {
        public int CarrierId { get; set; }
        public virtual Carrier? Carrier { get; set; }
        public int OrderDesi{ get; set; }
        public DateTime OrderTime{ get; set; }
        public decimal OrderCarrierCost{ get; set; }
    }
}
