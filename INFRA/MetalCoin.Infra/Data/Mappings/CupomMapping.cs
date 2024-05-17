using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Infra.Data.Mappings
{
    public class CupomMapping : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("Cupons");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoCupom)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(p => p.ValorDesconto)
              .HasColumnType("decimal")
              .IsRequired();

            builder.Property(p => p.QtdCuponsLiberados)
              .HasColumnType("int")
              .IsRequired();

            builder.Property(p => p.QtdCuponsUsados)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.TipoDesconto)
            .HasColumnType("varchar(100)")
            .IsRequired();

            builder.Property(p => p.StatusCupom)
            .HasColumnType("varchar(100)")
            .IsRequired();

            builder.Property(p => p.DataValidade)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
