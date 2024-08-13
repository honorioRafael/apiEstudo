using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Map
{
    public class EmployeeTaskMap : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> builder)
        {
            builder.ToTable("tarefas");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Description).HasColumnName("descricao");
        }
    }
}
