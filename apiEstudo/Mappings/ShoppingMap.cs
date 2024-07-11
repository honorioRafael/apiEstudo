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
            builder.Property(x => x.EmployeeId).HasColumnName("funcionario_id");
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.Value).HasColumnName("valor");
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.ShippingStatusId).HasColumnName("envio_status");

            builder.HasOne(x => x.Employee)
                .WithMany(e => e.Shoppings)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ShippingStatus)
               .WithMany(e => e.ListShoppings)
               .HasForeignKey(e => e.ShippingStatusId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
