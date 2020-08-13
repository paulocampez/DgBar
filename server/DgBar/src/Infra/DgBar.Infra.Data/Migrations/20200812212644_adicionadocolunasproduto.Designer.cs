﻿// <auto-generated />
using System;
using DgBar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DgBar.Infra.Data.Migrations
{
    [DbContext(typeof(DgBarContext))]
    [Migration("20200812212644_adicionadocolunasproduto")]
    partial class adicionadocolunasproduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DgBar.Domain.Models.Comanda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumeroComanda")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("comandas");
                });

            modelBuilder.Entity("DgBar.Domain.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroComanda")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("DgBar.Domain.Models.Produto", b =>
                {
                    b.HasOne("DgBar.Domain.Models.Comanda", null)
                        .WithMany("Produtos")
                        .HasForeignKey("ComandaId");
                });
#pragma warning restore 612, 618
        }
    }
}
