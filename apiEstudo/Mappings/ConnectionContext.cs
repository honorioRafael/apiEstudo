using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Mappings
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new EmployeeTaskMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ComprasMap());
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Compras> Compras { get; set; }
    }
}
