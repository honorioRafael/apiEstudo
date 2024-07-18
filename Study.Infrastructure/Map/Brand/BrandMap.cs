using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Map
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("marcas");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
