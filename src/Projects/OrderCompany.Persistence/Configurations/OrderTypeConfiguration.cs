using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderCompany.Domain.Entities;

namespace OrderCompany.Persistence.Configurations;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ORDER_ID");
        builder.Property(x => x.CarrierId).HasColumnName("CARRIER_ID");
        builder.Property(x => x.OrderDesi).HasColumnName("ORDER_DESI");
        builder.Property(x => x.OrderTime).HasColumnName("ORDER_TIME");
        builder.Property(x => x.OrderCarrierCost).HasColumnName("ORDER_CARRIER_COST").HasColumnType("decimal(18,2)");
        builder.HasOne(x => x.Carrier);
    }
}