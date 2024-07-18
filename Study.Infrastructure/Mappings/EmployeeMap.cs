using apiEstudo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("funcionarios");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).HasColumnName("idade");
            builder.Property(x => x.EmployeeTaskId).HasColumnName("tarefa_id");

            builder.HasOne(x => x.EmployeeTask)
                .WithMany(t => t.Employees)
                .HasForeignKey(t => t.EmployeeTaskId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
