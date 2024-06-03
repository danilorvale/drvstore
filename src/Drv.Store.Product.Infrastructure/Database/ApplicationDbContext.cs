using Microsoft.EntityFrameworkCore;

namespace Drv.Store.Product.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Product>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("varchar(36)");
            builder.Property(a => a.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18,2)");

        });

    }

    public DbSet<Domain.Entities.Product> Products { get; set; }
}