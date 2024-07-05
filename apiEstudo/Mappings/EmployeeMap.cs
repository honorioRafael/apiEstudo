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
            builder.Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Property(x => x.ChangeDate).HasColumnName("changedate");

            builder.HasOne(x => x.EmployeeTask)
                .WithMany(t => t.Employees)
                .HasForeignKey(t => t.EmployeeTaskId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
