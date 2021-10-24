using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Infraestrutura.Configuration
{
    public class ContaConfiguration : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("CONTASBANCARIAS");
        }
    }
}
