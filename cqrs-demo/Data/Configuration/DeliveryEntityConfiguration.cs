using cqrs_demo.Domain.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rammus.Data.Stock
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
