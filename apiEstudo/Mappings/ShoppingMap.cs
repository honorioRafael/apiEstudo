using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ShoppingMap : IEntityTypeConfiguration<Shopping>
    {
        public void Configure(EntityTypeBuilder<Shopping> builder)
        {
            builder.ToTable("compras");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.EmployeeId).HasColumnName("employeeid");
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.ProductId).HasColumnName("produtoid");
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Value).HasColumnName("valor");
            builder.Property(x => x.TransationDate).HasColumnName("data_compra");
            builder.Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Property(x => x.ChangeDate).HasColumnName("changedate");

            builder.HasOne(x => x.Employee)
                .WithMany(e => e.Shoppings)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ListShopping)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
