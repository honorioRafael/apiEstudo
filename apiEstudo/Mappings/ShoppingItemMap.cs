using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ShoppingItemMap : IEntityTypeConfiguration<ShoppingItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingItem> builder)
        {
            builder.ToTable("produtos_compra");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.ProductId).HasColumnName("produto_id");
            builder.Property(x => x.ShoppingId).HasColumnName("compra_id");
            builder.Property(x => x.Quantity).HasColumnName("quantidade");

            builder.HasOne(x => x.Shopping)
                .WithMany(s => s.ListShoppingItem)
                .HasForeignKey(x => x.ShoppingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(s => s.ListShoppingList)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
