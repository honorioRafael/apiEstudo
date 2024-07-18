using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantidade");
            builder.Property(x => x.BrandId).HasColumnName("marca_id");

            builder.Property(x => x.BrandId).IsRequired();
            builder.HasOne(x => x.Brand)
                   .WithMany(p => p.ListProduct)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
