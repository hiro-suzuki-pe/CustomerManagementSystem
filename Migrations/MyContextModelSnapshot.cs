﻿// <auto-generated />
using System;
using CustomerManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerManagementSystem.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagementSystem.Models.tbl_action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("action_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("action_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("action_staffId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("CustomerManagementSystem.Models.tbl_company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("company_kana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("delete_flag")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CustomerManagementSystem.Models.tbl_customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<string>("customer_kana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("delete_flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("first_action_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("input_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("input_staff_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.Property<string>("tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_staff_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerManagementSystem.Models.tbl_staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("admin_flag")
                        .HasColumnType("bit");

                    b.Property<bool>("delete_flag")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staff_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });
#pragma warning restore 612, 618
        }
    }
}
