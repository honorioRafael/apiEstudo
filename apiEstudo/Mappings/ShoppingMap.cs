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
        }
    }
}
