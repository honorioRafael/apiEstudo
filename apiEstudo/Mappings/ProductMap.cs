using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produtos");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.Property(x => x.BrandId).HasColumnName("brandid");
            builder.Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Property(x => x.ChangeDate).HasColumnName("changedate");

            builder.Property(x => x.BrandId).IsRequired();
            builder.HasOne(x => x.Brand)
                   .WithMany(p => p.Products)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
