using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Dominio.ObjetosDeValor;
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

            builder.Entity<Documento>().HasNoKey();

            //builder.Entity<ContaBancaria>()
            //   .HasData(new List<ContaBancaria>(){
            //        new ContaBancaria(1,"Teste Nome", "02025032161", "1010", "2020", new Banco(1,"070", "BRB - BANCO DE BRASILIA"))
            //   });

            builder.Entity<Banco>()
               .HasData(new List<Banco>(){
                    new Banco(1, "00001", "BANCO DO BRASIL"),
               });
        }
    }
}
