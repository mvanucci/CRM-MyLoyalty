﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLoyalty.Models;

namespace MyLoyalty.Migrations
{
    [DbContext(typeof(MyLoyaltyContext))]
    [Migration("20181106051341_fix_cliente_8")]
    partial class fix_cliente_8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyLoyalty.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Pesquisaid");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("dataNascimento");

                    b.Property<string>("email");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("pdtEncontrado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("produtoid");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("vendaRealizada");

                    b.HasKey("id");

                    b.HasIndex("Pesquisaid");

                    b.HasIndex("produtoid");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MyLoyalty.Models.Pesquisa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("accProduto");

                    b.Property<int>("atendimento");

                    b.Property<int>("notaVendedor");

                    b.Property<int>("status");

                    b.HasKey("id");

                    b.ToTable("Pesquisa");
                });

            modelBuilder.Entity("MyLoyalty.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("codigo");

                    b.Property<string>("cor")
                        .IsRequired();

                    b.Property<int>("estoque");

                    b.Property<string>("genero")
                        .IsRequired();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.Property<int>("tamanho");

                    b.Property<string>("tipo")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MyLoyalty.Models.Cliente", b =>
                {
                    b.HasOne("MyLoyalty.Models.Pesquisa")
                        .WithMany("cliente")
                        .HasForeignKey("Pesquisaid");

                    b.HasOne("MyLoyalty.Models.Produto", "produto")
                        .WithMany("cliente")
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
