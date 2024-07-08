using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ShoppingListMap : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.ToTable("produtos_compra");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).HasColumnName("productid");
            builder.Property(x => x.ShoppingId).HasColumnName("shopid");
            builder.Property(x => x.Quantity).HasColumnName("quantity");

            builder.HasOne(x => x.Shopping)
                .WithMany(s => s.Products)
                .HasForeignKey(x => x.ShoppingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(s => s.ListShoppingList)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
