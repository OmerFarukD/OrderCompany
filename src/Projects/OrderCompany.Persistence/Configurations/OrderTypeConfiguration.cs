using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderCompany.Domain.Entities;

namespace OrderCompany.Persistence.Configurations;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("OrderId");
        builder.Property(x => x.CarrierId).HasColumnName("CarrierId");
        builder.Property(x => x.OrderDesi).HasColumnName("OrderDesi");
        builder.Property(x => x.OrderTime).HasColumnName("OrderTime");
        builder.Property(x => x.OrderCarrierCost).HasColumnName("OrderCarrierCost").HasColumnType("decimal(18,2)");
        builder.HasOne(x => x.Carrier);
    }
}