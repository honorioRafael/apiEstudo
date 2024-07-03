using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ComprasMap : IEntityTypeConfiguration<Compras>
    {
        public void Configure(EntityTypeBuilder<Compras> builder)
        {
            builder.ToTable("compras");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.EmployeeId).HasColumnName("employeeid");
            builder.Property(x => x.ProductId).HasColumnName("produtoid");
            builder.Property(x => x.Value).HasColumnName("valor");
            builder.Property(x => x.TransationDate).HasColumnName("data_compra");
        }
    }
}
