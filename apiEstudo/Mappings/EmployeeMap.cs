using apiEstudo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).HasColumnName("age");
            builder.Property(x => x.EmployeeTaskId).HasColumnName("taskId");
        }
    }
}
