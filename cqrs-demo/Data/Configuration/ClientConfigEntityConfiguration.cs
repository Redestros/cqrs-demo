using cqrs_demo.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_demo.Data.Configuration
{
    public class ClientConfigEntityConfiguration : IEntityTypeConfiguration<ClientConfiguration>
    {
        public void Configure(EntityTypeBuilder<ClientConfiguration> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
