using cqrs_demo.Domain.Common;
using cqrs_demo.Domain.Customers;
using cqrs_demo.Domain.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rammus.Data.Stock;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cqrs_demo.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ClientConfiguration> ClientConfigurations { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder
           .UseLazyLoadingProxies()
           .UseSqlServer(configuration["ConnectionStrings:CQRSDemo"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new OrderEntityConfiguration());
            builder.ApplyConfiguration(new DeliveryEntityConfiguration());
        }

        public override int SaveChanges()
        {

            // Get all the entities that inherit from AuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set
                // the CreatedAt and CreatedBy properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationDate = DateTime.UtcNow;
                }
                else
                {
                    // If the state is Modified then we don't want
                    // to modify the CreatedAt and CreatedBy properties
                    // so we set their state as IsModified to false
                    Entry((BaseEntity)entityEntry.Entity).Property(p => p.CreationDate).IsModified = false;
                }

                // In any case we always want to set the properties
                // ModifiedAt and ModifiedBy
                ((BaseEntity)entityEntry.Entity).LastModifiedDate = DateTime.UtcNow;
            }

            // After we set all the needed properties
            // we call the base implementation of SaveChanges
            // to actually save our entities in the database
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Get all the entities that inherit from AuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set
                // the CreatedAt and CreatedBy properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationDate = DateTime.UtcNow;
                }
                else
                {
                    // If the state is Modified then we don't want
                    // to modify the CreatedAt and CreatedBy properties
                    // so we set their state as IsModified to false
                    Entry((BaseEntity)entityEntry.Entity).Property(p => p.CreationDate).IsModified = false;
                }

                // In any case we always want to set the properties
                // ModifiedAt and ModifiedBy
                ((BaseEntity)entityEntry.Entity).LastModifiedDate = DateTime.UtcNow;
            }

            // After we set all the needed properties
            // we call the base implementation of SaveChangesAsync
            // to actually save our entities in the database
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
