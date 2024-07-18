using Study.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Infrastructure.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Password).HasColumnName("senha");
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
