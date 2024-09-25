﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBakeryApp.Infrastructure;

#nullable disable

namespace TheBakeryApp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheBakeryApp.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Fidelizado")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TheBakeryApp.Model.CupomFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("CupomFiscal");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CupomFiscalId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CupomFiscalId");

                    b.HasIndex("VendaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroCupomFiscal")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("TheBakeryApp.Model.VendaProduto", b =>
                {
                    b.Property<int>("VendaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("VendaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("VendaProduto");
                });

            modelBuilder.Entity("TheBakeryApp.Model.CupomFiscal", b =>
                {
                    b.HasOne("TheBakeryApp.Model.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Produto", b =>
                {
                    b.HasOne("TheBakeryApp.Model.CupomFiscal", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CupomFiscalId");

                    b.HasOne("TheBakeryApp.Model.Venda", null)
                        .WithMany("Produtos")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Venda", b =>
                {
                    b.HasOne("TheBakeryApp.Model.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TheBakeryApp.Model.VendaProduto", b =>
                {
                    b.HasOne("TheBakeryApp.Model.Produto", "Produto")
                        .WithMany("VendasProduto")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheBakeryApp.Model.Venda", "Venda")
                        .WithMany("VendasProduto")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("TheBakeryApp.Model.CupomFiscal", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Produto", b =>
                {
                    b.Navigation("VendasProduto");
                });

            modelBuilder.Entity("TheBakeryApp.Model.Venda", b =>
                {
                    b.Navigation("Produtos");

                    b.Navigation("VendasProduto");
                });
#pragma warning restore 612, 618
        }
    }
}
