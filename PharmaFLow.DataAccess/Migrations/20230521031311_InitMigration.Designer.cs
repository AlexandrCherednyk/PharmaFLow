﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmaFLow.DataAccess.DbContexts;

#nullable disable

namespace PharmaFLow.DataAccess.Migrations
{
    [DbContext(typeof(PharmaFlowDbContext))]
    [Migration("20230521031311_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Pharmacies.PharmacyMemberPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<Guid>("PharmacyID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("pharmacy_id");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_pharmacy_members");

                    b.HasIndex("PharmacyID")
                        .HasDatabaseName("ix_pharmacy_members_pharmacy_id");

                    b.ToTable("pharmacy_members", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Pharmacies.PharmacyPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_pharmacies");

                    b.ToTable("pharmacies", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductCharacteristicPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("ID")
                        .HasName("pk_product_characteristics");

                    b.ToTable("product_characteristics", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductManufacturerPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_product_manufacturers");

                    b.ToTable("product_manufacturers", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<Guid>("ManufacturerID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("manufacturer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("PathToFile")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("path_to_file");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<Guid>("TypeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("type_id");

                    b.HasKey("ID")
                        .HasName("pk_products");

                    b.HasIndex("ManufacturerID")
                        .HasDatabaseName("ix_products_manufacturer_id");

                    b.HasIndex("TypeID")
                        .HasDatabaseName("ix_products_type_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductTypePersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_product_types");

                    b.ToTable("product_types", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Reports.InputReportPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_price");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("ID")
                        .HasName("pk_input_reports");

                    b.HasIndex("ProductID")
                        .HasDatabaseName("ix_input_reports_product_id");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_input_reports_user_id");

                    b.ToTable("input_reports", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Reports.OutputReportPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_price");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("ID")
                        .HasName("pk_output_reports");

                    b.HasIndex("ProductID")
                        .HasDatabaseName("ix_output_reports_product_id");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_output_reports_user_id");

                    b.ToTable("output_reports", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.UserPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hash");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ProductCharacteristicPersistenceProductPersistence", b =>
                {
                    b.Property<Guid>("CharacteristicsID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("characteristics_id");

                    b.Property<Guid>("ProductsID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("products_id");

                    b.HasKey("CharacteristicsID", "ProductsID")
                        .HasName("pk_product_characteristic_persistence_product_persistence");

                    b.HasIndex("ProductsID")
                        .HasDatabaseName("ix_product_characteristic_persistence_product_persistence_products_id");

                    b.ToTable("product_characteristic_persistence_product_persistence", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Pharmacies.PharmacyMemberPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Pharmacies.PharmacyPersistence", "Pharmacy")
                        .WithMany("Members")
                        .HasForeignKey("PharmacyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pharmacy_members_pharmacies_pharmacy_id");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductManufacturerPersistence", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_product_manufacturers_manufacturer_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductTypePersistence", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_product_types_type_id");

                    b.Navigation("Manufacturer");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Reports.InputReportPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductPersistence", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_input_reports_products_product_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.UserPersistence", "User")
                        .WithMany("InputReports")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_input_reports_users_user_id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Reports.OutputReportPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductPersistence", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_output_reports_products_product_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.UserPersistence", "User")
                        .WithMany("OutputReports")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_output_reports_users_user_id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductCharacteristicPersistenceProductPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductCharacteristicPersistence", null)
                        .WithMany()
                        .HasForeignKey("CharacteristicsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_characteristic_persistence_product_persistence_product_characteristics_characteristics_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.Products.ProductPersistence", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_characteristic_persistence_product_persistence_products_products_id");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Pharmacies.PharmacyPersistence", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductManufacturerPersistence", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Products.ProductTypePersistence", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.UserPersistence", b =>
                {
                    b.Navigation("InputReports");

                    b.Navigation("OutputReports");
                });
#pragma warning restore 612, 618
        }
    }
}
