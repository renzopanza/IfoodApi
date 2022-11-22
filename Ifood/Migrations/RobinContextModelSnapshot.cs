﻿// <auto-generated />
using System;
using Ifood.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ifood.Migrations
{
    [DbContext(typeof(RobinContext))]
    partial class RobinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ifood.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"), 1L, 1);

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdRestaurante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Ifood.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 1L, 1);

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Ifood.Models.RestauranteModel", b =>
                {
                    b.Property<int>("IdRestaurante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRestaurante"), 1L, 1);

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("IdRestaurante");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Ifood.Models.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LoginUser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Ifood.Models.PedidoModel", b =>
                {
                    b.HasOne("Ifood.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ifood.Models.RestauranteModel", "Restaurante")
                        .WithMany()
                        .HasForeignKey("IdRestaurante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ifood.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Restaurante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ifood.Models.ProdutoModel", b =>
                {
                    b.HasOne("Ifood.Models.RestauranteModel", "Restaurante")
                        .WithMany()
                        .HasForeignKey("IdRestaurante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });
#pragma warning restore 612, 618
        }
    }
}
