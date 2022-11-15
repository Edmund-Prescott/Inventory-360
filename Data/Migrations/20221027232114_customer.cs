using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace instrumentRentals2.Data.Migrations
{
    public partial class customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instrument",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrument", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rentalAgreement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rentalStart = table.Column<DateTime>(nullable: false),
                    instrumentid = table.Column<int>(nullable: true),
                    customerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentalAgreement", x => x.id);
                    table.ForeignKey(
                        name: "FK_rentalAgreement_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rentalAgreement_instrument_instrumentid",
                        column: x => x.instrumentid,
                        principalTable: "instrument",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rentalAgreement_customerid",
                table: "rentalAgreement",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_rentalAgreement_instrumentid",
                table: "rentalAgreement",
                column: "instrumentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rentalAgreement");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "instrument");
        }
    }
}
