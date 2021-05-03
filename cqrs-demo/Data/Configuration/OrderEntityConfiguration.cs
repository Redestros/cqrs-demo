using cqrs_demo.Domain.Stock;
using Microsoft.EntityFrameworkCore;

namespace cqrs_demo.Data.Configuration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products)
                .WithOne(y => y.Order)
                .HasForeignKey(y => y.OrderId);
        }
    }
}
