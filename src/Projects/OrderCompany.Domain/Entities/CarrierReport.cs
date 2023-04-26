using OrderCompany.Persistence.Entities;

namespace OrderCompany.Domain.Entities;

public class CarrierReport : Entity
{
    public int CarrierId { get; set; }
    public virtual ICollection<Carrier> Carrier { get; set; }
    
    public decimal CarrierCost { get; set; }
    public DateTime CarrierReportDate { get; set; }
}