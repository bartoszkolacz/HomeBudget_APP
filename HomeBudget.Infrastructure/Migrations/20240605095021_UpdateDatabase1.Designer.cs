﻿// <auto-generated />
using System;
using HomeBudget.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeBudget.Infrastructure.Migrations
{
    [DbContext(typeof(HomeBudgetDbContext))]
    [Migration("20240605095021_UpdateDatabase1")]
    partial class UpdateDatabase1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeBudget.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transactionId"));

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("transactionAmount")
                        .HasColumnType("real");

                    b.Property<string>("transactionCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("transactionCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("transactionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transactionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("transactionId");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
