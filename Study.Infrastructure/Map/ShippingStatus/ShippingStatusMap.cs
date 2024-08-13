using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Map
{
    public class ShippingStatusMap : IEntityTypeConfiguration<ShippingStatus>
    {
        public void Configure(EntityTypeBuilder<ShippingStatus> builder)
        {
            builder.ToTable("envio_status");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Description).HasColumnName("descricao");
            builder.Property(x => x.Description).IsRequired(); ;
        }
    }
}
