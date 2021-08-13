﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetfritzServices.CadastroService.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetfritzCadastroService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210813005444_CreatingTables")]
    partial class CreatingTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NetfritzCadastroService.Domain.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("NetfritzCadastroService.Domain.Models.Administrador", b =>
                {
                    b.HasBaseType("NetfritzCadastroService.Domain.Models.Usuario");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("NetfritzCadastroService.Domain.Models.Cliente", b =>
                {
                    b.HasBaseType("NetfritzCadastroService.Domain.Models.Usuario");

                    b.Property<string>("Cartao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NetfritzCadastroService.Domain.Models.Administrador", b =>
                {
                    b.HasOne("NetfritzCadastroService.Domain.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("NetfritzCadastroService.Domain.Models.Administrador", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetfritzCadastroService.Domain.Models.Cliente", b =>
                {
                    b.HasOne("NetfritzCadastroService.Domain.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("NetfritzCadastroService.Domain.Models.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}