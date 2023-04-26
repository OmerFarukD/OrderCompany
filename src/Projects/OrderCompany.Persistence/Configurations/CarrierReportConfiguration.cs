using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderCompany.Domain.Entities;

namespace OrderCompany.Persistence.Configurations;

public class CarrierReportConfiguration : IEntityTypeConfiguration<CarrierReport>
{
    public void Configure(EntityTypeBuilder<CarrierReport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CarrierReportId");
        builder.Property(x => x.CarrierId).HasColumnName("CarrierId");
        builder.Property(x => x.CarrierReportDate).HasColumnName("CarrierReportDate");
        builder.HasMany(c => c.Carrier);
    }
}