using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class EmployeeTaskMap : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> builder)
        {
            builder.ToTable("Task");
            builder.Property(x => x.Name).HasColumnName("taskName");
            builder.Property(x => x.Description).HasColumnName("taskDescription");
        }
    }
}
