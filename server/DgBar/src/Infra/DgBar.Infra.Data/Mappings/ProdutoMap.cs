using DgBar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Descricao);
            builder.Property(c => c.NumeroComanda);
            builder.Property(c => c.Valor);
            builder.Property(c => c.Quantidade);
            builder.Property(c => c.Desconto);
            builder.Property(c => c.Observacao);

        }
    }
}
