﻿// <auto-generated />
using System;
using DesafioNET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioNET.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210528185739_Fix-Transactions")]
    partial class FixTransactions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioNET.Data.Entites.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("PlaceOwner")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionValue")
                        .HasColumnType("Money");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("TransactionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DesafioNET.Data.Entites.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPositive")
                        .HasColumnType("bit");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeId = 1,
                            IsPositive = true,
                            TypeName = "Débito"
                        },
                        new
                        {
                            TransactionTypeId = 2,
                            IsPositive = false,
                            TypeName = "Boleto"
                        },
                        new
                        {
                            TransactionTypeId = 3,
                            IsPositive = false,
                            TypeName = "Financiamento"
                        },
                        new
                        {
                            TransactionTypeId = 4,
                            IsPositive = true,
                            TypeName = "Crédito"
                        },
                        new
                        {
                            TransactionTypeId = 5,
                            IsPositive = true,
                            TypeName = "Recebimento Empréstimo"
                        },
                        new
                        {
                            TransactionTypeId = 6,
                            IsPositive = true,
                            TypeName = "Vendas"
                        },
                        new
                        {
                            TransactionTypeId = 7,
                            IsPositive = true,
                            TypeName = "Recebimento TED"
                        },
                        new
                        {
                            TransactionTypeId = 8,
                            IsPositive = true,
                            TypeName = "Recebimento DOC"
                        },
                        new
                        {
                            TransactionTypeId = 9,
                            IsPositive = false,
                            TypeName = "Aluguel"
                        });
                });

            modelBuilder.Entity("DesafioNET.Data.Entites.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DesafioNET.Data.Entites.Transaction", b =>
                {
                    b.HasOne("DesafioNET.Data.Entites.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioNET.Data.Entites.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesafioNET.Data.Entites.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
