using cqrs_demo.Domain.Stock;
using Microsoft.EntityFrameworkCore;

namespace Rammus.Data.Stock
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
