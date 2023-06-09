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
    [Migration("20230531005705_AddMeetings")]
    partial class AddMeetings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Contacts.ContactPersistence", b =>
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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_contacts");

                    b.ToTable("contacts", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ContactID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("contact_id");

                    b.Property<Guid>("MedicalFacilityID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("medical_facility_id");

                    b.Property<Guid>("PositionID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("position_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("ID")
                        .HasName("pk_medical_facility_contacts");

                    b.HasIndex("ContactID")
                        .HasDatabaseName("ix_medical_facility_contacts_contact_id");

                    b.HasIndex("MedicalFacilityID")
                        .HasDatabaseName("ix_medical_facility_contacts_medical_facility_id");

                    b.HasIndex("PositionID")
                        .HasDatabaseName("ix_medical_facility_contacts_position_id");

                    b.ToTable("medical_facility_contacts", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPositionPersistence", b =>
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
                        .HasName("pk_medical_facility_contact_positions");

                    b.ToTable("medical_facility_contact_positions", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<Guid>("TypeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("type_id");

                    b.HasKey("ID")
                        .HasName("pk_medical_facilities");

                    b.HasIndex("TypeID")
                        .HasDatabaseName("ix_medical_facilities_type_id");

                    b.ToTable("medical_facilities", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityTypePersistence", b =>
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
                        .HasName("pk_medical_facility_types");

                    b.ToTable("medical_facility_types", (string)null);
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Meetings.MeetPersistence", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasColumnName("end");

                    b.Property<Guid>("StaffTargetID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("staff_target_id");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2")
                        .HasColumnName("start");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("ID")
                        .HasName("pk_meetings");

                    b.HasIndex("StaffTargetID")
                        .HasDatabaseName("ix_meetings_staff_target_id");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_meetings_user_id");

                    b.ToTable("meetings", (string)null);
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

                    b.Property<DateTime?>("ConfirmedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("confirmed_on");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<Guid>("StaffTargetID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("staff_target_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_price");

                    b.Property<Guid?>("UserConfirmatorID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_confirmator_id");

                    b.Property<Guid>("UserCreatorID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_creator_id");

                    b.HasKey("ID")
                        .HasName("pk_output_reports");

                    b.HasIndex("ProductID")
                        .HasDatabaseName("ix_output_reports_product_id");

                    b.HasIndex("StaffTargetID")
                        .HasDatabaseName("ix_output_reports_staff_target_id");

                    b.HasIndex("UserConfirmatorID")
                        .HasDatabaseName("ix_output_reports_user_confirmator_id");

                    b.HasIndex("UserCreatorID")
                        .HasDatabaseName("ix_output_reports_user_creator_id");

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

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.Contacts.ContactPersistence", "Contact")
                        .WithMany("MedicalFacilityContacts")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medical_facility_contacts_contacts_contact_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityPersistence", "MedicalFacility")
                        .WithMany("Staff")
                        .HasForeignKey("MedicalFacilityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medical_facility_contacts_medical_facilities_medical_facility_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPositionPersistence", "Position")
                        .WithMany("Staff")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medical_facility_contacts_medical_facility_contact_positions_position_id");

                    b.Navigation("Contact");

                    b.Navigation("MedicalFacility");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityTypePersistence", "Type")
                        .WithMany("MedicalFacilities")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medical_facilities_medical_facility_types_type_id");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Meetings.MeetPersistence", b =>
                {
                    b.HasOne("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPersistence", "StaffTarget")
                        .WithMany()
                        .HasForeignKey("StaffTargetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_meetings_medical_facility_contacts_staff_target_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.UserPersistence", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_meetings_users_user_id");

                    b.Navigation("StaffTarget");

                    b.Navigation("User");
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

                    b.HasOne("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPersistence", "StaffTarget")
                        .WithMany()
                        .HasForeignKey("StaffTargetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_output_reports_medical_facility_contacts_staff_target_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.UserPersistence", "UserConfirmator")
                        .WithMany()
                        .HasForeignKey("UserConfirmatorID")
                        .HasConstraintName("fk_output_reports_users_user_confirmator_id");

                    b.HasOne("PharmaFLow.DataAccess.Persistences.UserPersistence", "UserCreator")
                        .WithMany()
                        .HasForeignKey("UserCreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_output_reports_users_user_creator_id");

                    b.Navigation("Product");

                    b.Navigation("StaffTarget");

                    b.Navigation("UserConfirmator");

                    b.Navigation("UserCreator");
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

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.Contacts.ContactPersistence", b =>
                {
                    b.Navigation("MedicalFacilityContacts");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityContactPositionPersistence", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityPersistence", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PharmaFLow.DataAccess.Persistences.MedicalFacilities.MedicalFacilityTypePersistence", b =>
                {
                    b.Navigation("MedicalFacilities");
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
                });
#pragma warning restore 612, 618
        }
    }
}
