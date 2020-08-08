using DgBar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.Mappings
{
    public class ComandaMap : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Produtos);
        }
    }
}
