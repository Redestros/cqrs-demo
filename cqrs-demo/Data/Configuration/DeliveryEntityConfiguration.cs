using cqrs_demo.Domain.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_demo.Data.Configuration
{
    public class DeliveryEntityConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Order)
                .WithOne(y => y.Delivery)
                .HasForeignKey<Order>(y => y.DeliveryId);
        }
    }
}
