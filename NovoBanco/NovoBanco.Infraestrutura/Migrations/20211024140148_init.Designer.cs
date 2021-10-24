﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NovoBanco.Infraestrutura.Context;

namespace NovoBanco.Infraestrutura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211024140148_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NovoBanco.Dominio.Entidades.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BANCOS");
                });

            modelBuilder.Entity("NovoBanco.Dominio.Entidades.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("Conta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("CONTASBANCARIAS");
                });

            modelBuilder.Entity("NovoBanco.Dominio.Entidades.ContaBancaria", b =>
                {
                    b.HasOne("NovoBanco.Dominio.Entidades.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });
#pragma warning restore 612, 618
        }
    }
}