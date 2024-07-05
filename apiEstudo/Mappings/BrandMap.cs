using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("marcas");
            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Property(x => x.ChangeDate).HasColumnName("changedate");
        }
    }
}
