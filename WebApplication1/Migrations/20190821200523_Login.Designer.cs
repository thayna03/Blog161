﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    [Migration("20190821200523_Login")]
    partial class Login
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WebApplication1.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor");

                    b.Property<DateTime>("DataComentario");

                    b.Property<string>("Descricao");

                    b.Property<int?>("MensagemId");

                    b.Property<string>("Nome");

                    b.Property<string>("Titulo");

                    b.HasKey("ComentarioId");

                    b.HasIndex("MensagemId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("WebApplication1.Models.Mensagem", b =>
                {
                    b.Property<int>("MensagemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<string>("Descricao");

                    b.Property<string>("Titulo");

                    b.HasKey("MensagemId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("WebApplication1.Models.Comentario", b =>
                {
                    b.HasOne("WebApplication1.Models.Mensagem", "Mensagem")
                        .WithMany("Comentarios")
                        .HasForeignKey("MensagemId");
                });

            modelBuilder.Entity("WebApplication1.Models.Mensagem", b =>
                {
                    b.HasOne("WebApplication1.Models.Categoria", "Categorias")
                        .WithMany("Mensagems")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
