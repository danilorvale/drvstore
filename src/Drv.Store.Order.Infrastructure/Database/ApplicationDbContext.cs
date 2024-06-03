using Drv.Store.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drv.Store.Order.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("varchar(36)");
            builder.Property(a => a.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.Email).IsRequired().HasColumnType("varchar(100)");
            builder.HasMany(a => a.Orders)
                   .WithOne(a => a.Customer)
                   .HasForeignKey(a => a.CustomerId);

        });

        modelBuilder.Entity<Domain.Entities.Order>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("varchar(36)");
            builder.Property(a => a.CreatedAt).IsRequired().HasColumnType("datetime");
            builder.HasMany(a => a.Items)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.Id);

        });

        modelBuilder.Entity<OrderItem>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("varchar(36)");
            builder.Property(a => a.ProductId).IsRequired().HasColumnType("varchar(36)");
            builder.Property(a => a.Quantity).IsRequired().HasColumnType("int");

        });

    }

    public DbSet<Domain.Entities.Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
}