using cqrs_demo.Domain.Common;
using cqrs_demo.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_demo.Data.Configuration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Address)
                .WithOne(y => y.Customer)
                .HasForeignKey<Address>(y => y.CustomerId)
                .IsRequired(false);

            builder.HasOne(x => x.Configuration)
                .WithOne(y => y.Customer)
                .HasForeignKey<ClientConfiguration>(y => y.CustomerId);
        }
    }
}
