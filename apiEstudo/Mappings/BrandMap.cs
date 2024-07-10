﻿using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEstudo.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("marcas");
            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
        }
    }
}
