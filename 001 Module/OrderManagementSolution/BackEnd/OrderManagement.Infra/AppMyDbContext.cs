using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public class AppMyDbContext : DbContext
{
    public AppMyDbContext(DbContextOptions<AppMyDbContext> options)
       : base(options)
    {
    }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderItems> OrderItems { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }


    public virtual DbSet<Category> Categories { get; set; }

}
