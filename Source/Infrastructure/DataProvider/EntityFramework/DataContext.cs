using Microsoft.EntityFrameworkCore;
using MoneyMe.Api.Source.Domain.Entities;

namespace MoneyMe.Api.Source.Infrastructure.DataProvider.EntityFramework
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public virtual DbSet<BlocklistedDomainName> BlocklistedDomainNames { get; set; }
        public virtual DbSet<BlocklistedMobileNo> BlocklistedMobileNos { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=Admin123!;Server=localhost;Port=5432;Database=MoneyMeDb; Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

        }
    }
}
