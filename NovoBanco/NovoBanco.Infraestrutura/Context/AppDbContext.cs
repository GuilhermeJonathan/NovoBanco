using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Infraestrutura.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Infraestrutura.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region DBSet
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContaConfiguration());
            builder.ApplyConfiguration(new BancoConfiguration());

            builder.Entity<Banco>()
               .HasData(new List<Banco>(){
                   new Banco(1, "001", "BANCO DO BRASIL"),
                   new Banco(2, "070", "BRB"),
                   new Banco(3, "104", "CAIXA ECONÔMICA FEDERAL"),
                   new Banco(4, "429", "BANCO INTER"),
                   new Banco(6, "237", "BRADESCO"),
                   new Banco(7, "008", "SANTANDER"),
                   new Banco(8, "756", "SICOOB"),
                   new Banco(9, "048", "ITAU"),
                   new Banco(10, "422", "SAFRA"),
                   new Banco(11, "477", "CITIBANK")
               });
        }
    }
}
