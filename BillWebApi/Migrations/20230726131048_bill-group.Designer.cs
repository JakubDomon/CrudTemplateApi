﻿// <auto-generated />
using System;
using BillWebApi.Database.DatabaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillWebApi.Migrations
{
    [DbContext(typeof(MSSQLContext))]
    [Migration("20230726131048_bill-group")]
    partial class billgroup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Bills.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cash")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Shop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("addedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("addedById");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Bills.BillUsersCash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("Cash")
                        .HasColumnType("int");

                    b.Property<int?>("UserIDId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("UserIDId");

                    b.ToTable("BillsUsersCash");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Group.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jakub",
                            Password = "$2a$11$nZ8sYFy6jKWx27BBlbT7vO3xVDJ4ikdzCAidbuA6S0.sSGZdA/6a2",
                            Surname = "Domoń"
                        });
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Bills.Bill", b =>
                {
                    b.HasOne("BillWebApi.Database.Models.DatabaseModels.Group.Group", null)
                        .WithMany("Bills")
                        .HasForeignKey("GroupId");

                    b.HasOne("BillWebApi.Database.Models.DatabaseModels.Users.User", "addedBy")
                        .WithMany()
                        .HasForeignKey("addedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("addedBy");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Bills.BillUsersCash", b =>
                {
                    b.HasOne("BillWebApi.Database.Models.DatabaseModels.Bills.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillWebApi.Database.Models.DatabaseModels.Users.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDId");

                    b.Navigation("Bill");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Users.User", b =>
                {
                    b.HasOne("BillWebApi.Database.Models.DatabaseModels.Group.Group", null)
                        .WithMany("Users")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("BillWebApi.Database.Models.DatabaseModels.Group.Group", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
