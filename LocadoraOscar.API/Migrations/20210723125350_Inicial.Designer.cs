﻿// <auto-generated />
using System;
using LocadoraOscar.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraOscar.API.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    [Migration("20210723125350_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraOscar.API.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int?>("LocacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 793, DateTimeKind.Local).AddTicks(8196),
                            GeneroId = 1,
                            Nome = "O Poderoso Chefão"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3918),
                            GeneroId = 1,
                            Nome = "O Rei Leão"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3958),
                            GeneroId = 3,
                            Nome = "Star Wars"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3962),
                            GeneroId = 4,
                            Nome = "Intocáveis"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3966),
                            GeneroId = 2,
                            Nome = "O Exorcista"
                        });
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.FilmeLocacao", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("LocacaoId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "LocacaoId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("FilmesLocacoes");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(1179),
                            Nome = "Ação e Aventura"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3728),
                            Nome = "Terror"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3744),
                            Nome = "Ficção Científica"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataDeCriacao = new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3747),
                            Nome = "Comédia"
                        });
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPFDoCliente")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("DataDaLocacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Filme", b =>
                {
                    b.HasOne("LocadoraOscar.API.Models.Genero", "Genero")
                        .WithMany("Filmes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraOscar.API.Models.Locacao", null)
                        .WithMany("ListaDeFilmes")
                        .HasForeignKey("LocacaoId");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.FilmeLocacao", b =>
                {
                    b.HasOne("LocadoraOscar.API.Models.Filme", "Filme")
                        .WithMany("FilmesLocacoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraOscar.API.Models.Locacao", "Locacao")
                        .WithMany("FilmesLocacoes")
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Filme", b =>
                {
                    b.Navigation("FilmesLocacoes");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Genero", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("LocadoraOscar.API.Models.Locacao", b =>
                {
                    b.Navigation("FilmesLocacoes");

                    b.Navigation("ListaDeFilmes");
                });
#pragma warning restore 612, 618
        }
    }
}
