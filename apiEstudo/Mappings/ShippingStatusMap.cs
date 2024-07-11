using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class ShippingStatusMap : IEntityTypeConfiguration<ShippingStatus>
    {
        public void Configure(EntityTypeBuilder<ShippingStatus> builder)
        {
            builder.ToTable("envio_status");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Description).HasColumnName("descricao");
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
        }
    }
}
