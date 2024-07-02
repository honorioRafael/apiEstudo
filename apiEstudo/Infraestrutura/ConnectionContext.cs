using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<apiEstudo.Domain.Models.EmployeeTask> Tasks { get; set; }
    }
}
