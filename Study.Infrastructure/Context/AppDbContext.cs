using Microsoft.EntityFrameworkCore;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Map;

namespace Study.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new EmployeeTaskMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ShoppingMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ShoppingItemMap());
            modelBuilder.ApplyConfiguration(new ShippingStatusMap());
            modelBuilder.ApplyConfiguration(new IdControlMap());
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Marcas { get; set; }
        public DbSet<Shopping> Compras { get; set; }
        public DbSet<ShoppingItem> ShoppingLists { get; set; }
        public DbSet<ShippingStatus> ShippingStatus { get; set; }
        public DbSet<IdControl> IdControls { get; set; }
    }
}
