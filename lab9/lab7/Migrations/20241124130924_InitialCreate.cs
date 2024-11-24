using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherManufacturerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerCode);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MechanicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherMechanicDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.MechanicId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufacturerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherModelDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelCode);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerCode",
                        column: x => x.ManufacturerCode,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CurrentMileage = table.Column<int>(type: "int", nullable: false),
                    EngineSize = table.Column<double>(type: "float", nullable: false),
                    OtherCarDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicenceNumber);
                    table.ForeignKey(
                        name: "FK_Cars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelCode",
                        column: x => x.ModelCode,
                        principalTable: "Models",
                        principalColumn: "ModelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookings",
                columns: table => new
                {
                    SvcBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentReceivedYn = table.Column<bool>(type: "bit", nullable: false),
                    DatetimeOfService = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherSvcBookingDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookings", x => x.SvcBookingId);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Cars_LicenceNumber",
                        column: x => x.LicenceNumber,
                        principalTable: "Cars",
                        principalColumn: "LicenceNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MechanicsOnServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MechanicId = table.Column<int>(type: "int", nullable: false),
                    SvcBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicsOnServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicsOnServices_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "MechanicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicsOnServices_ServiceBookings_SvcBookingId",
                        column: x => x.SvcBookingId,
                        principalTable: "ServiceBookings",
                        principalColumn: "SvcBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelCode",
                table: "Cars",
                column: "ModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_MechanicId",
                table: "MechanicsOnServices",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicsOnServices_SvcBookingId",
                table: "MechanicsOnServices",
                column: "SvcBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerCode",
                table: "Models",
                column: "ManufacturerCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_CustomerId",
                table: "ServiceBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_LicenceNumber",
                table: "ServiceBookings",
                column: "LicenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicsOnServices");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "ServiceBookings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
