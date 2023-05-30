using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaFLow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medical_facility_contact_positions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_facility_contact_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medical_facility_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_facility_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_characteristics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_characteristics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_manufacturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_manufacturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medical_facilities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_facilities", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_facilities_medical_facility_types_type_id",
                        column: x => x.type_id,
                        principalTable: "medical_facility_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    manufacturer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    path_to_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_product_manufacturers_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "product_manufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_products_product_types_type_id",
                        column: x => x.type_id,
                        principalTable: "product_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_facility_contacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    medical_facility_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    position_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_facility_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_facility_contacts_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_medical_facility_contacts_medical_facilities_medical_facility_id",
                        column: x => x.medical_facility_id,
                        principalTable: "medical_facilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_medical_facility_contacts_medical_facility_contact_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "medical_facility_contact_positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "input_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_input_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_input_reports_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_input_reports_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_characteristic_persistence_product_persistence",
                columns: table => new
                {
                    characteristics_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    products_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_characteristic_persistence_product_persistence", x => new { x.characteristics_id, x.products_id });
                    table.ForeignKey(
                        name: "fk_product_characteristic_persistence_product_persistence_product_characteristics_characteristics_id",
                        column: x => x.characteristics_id,
                        principalTable: "product_characteristics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_characteristic_persistence_product_persistence_products_products_id",
                        column: x => x.products_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "output_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    confirmed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false),
                    user_creator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    staff_target_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_confirmator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_output_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_output_reports_medical_facility_contacts_staff_target_id",
                        column: x => x.staff_target_id,
                        principalTable: "medical_facility_contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_output_reports_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_output_reports_users_user_confirmator_id",
                        column: x => x.user_confirmator_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_output_reports_users_user_creator_id",
                        column: x => x.user_creator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_input_reports_product_id",
                table: "input_reports",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_input_reports_user_id",
                table: "input_reports",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_facilities_type_id",
                table: "medical_facilities",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_facility_contacts_contact_id",
                table: "medical_facility_contacts",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_facility_contacts_medical_facility_id",
                table: "medical_facility_contacts",
                column: "medical_facility_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_facility_contacts_position_id",
                table: "medical_facility_contacts",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_output_reports_product_id",
                table: "output_reports",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_output_reports_staff_target_id",
                table: "output_reports",
                column: "staff_target_id");

            migrationBuilder.CreateIndex(
                name: "ix_output_reports_user_confirmator_id",
                table: "output_reports",
                column: "user_confirmator_id");

            migrationBuilder.CreateIndex(
                name: "ix_output_reports_user_creator_id",
                table: "output_reports",
                column: "user_creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_characteristic_persistence_product_persistence_products_id",
                table: "product_characteristic_persistence_product_persistence",
                column: "products_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_manufacturer_id",
                table: "products",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_type_id",
                table: "products",
                column: "type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "input_reports");

            migrationBuilder.DropTable(
                name: "output_reports");

            migrationBuilder.DropTable(
                name: "product_characteristic_persistence_product_persistence");

            migrationBuilder.DropTable(
                name: "medical_facility_contacts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "product_characteristics");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "medical_facilities");

            migrationBuilder.DropTable(
                name: "medical_facility_contact_positions");

            migrationBuilder.DropTable(
                name: "product_manufacturers");

            migrationBuilder.DropTable(
                name: "product_types");

            migrationBuilder.DropTable(
                name: "medical_facility_types");
        }
    }
}
