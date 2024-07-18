﻿using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class IdControlMap : IEntityTypeConfiguration<IdControl>
    {
        public void Configure(EntityTypeBuilder<IdControl> builder)
        {
            builder.ToTable("controle_id");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.TableKey).HasColumnName("id_tabela");
            builder.Property(x => x.TableKey).IsRequired();
            builder.Property(x => x.TableName).HasColumnName("nome_tabela");
            builder.Property(x => x.TableName).IsRequired();
            builder.Property(x => x.NextId).HasColumnName("proximo_id");
            builder.Property(x => x.NextId).IsRequired();
        }
    }
}