using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Province = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Addresses = table.Column<string>(type: "text", nullable: false),
                    TaxPayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressesId = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    IdentityNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advisors_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NaceCode = table.Column<string>(type: "text", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdentityNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayers_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationName = table.Column<string>(type: "text", nullable: false),
                    TaxPayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessApplications_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    TaxPayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Obligations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObligationName = table.Column<string>(type: "text", nullable: false),
                    TaxPayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obligations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obligations_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TaxPayerId",
                table: "Addresses",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_AddressesId",
                table: "Advisors",
                column: "AddressesId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_ContactId",
                table: "Advisors",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessApplications_TaxPayerId",
                table: "BusinessApplications",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TaxPayerId",
                table: "Contacts",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Obligations_TaxPayerId",
                table: "Obligations",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_AdvisorId",
                table: "TaxPayers",
                column: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_TaxPayers_TaxPayerId",
                table: "Addresses",
                column: "TaxPayerId",
                principalTable: "TaxPayers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Contacts_ContactId",
                table: "Advisors",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_TaxPayers_TaxPayerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_TaxPayers_TaxPayerId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "BusinessApplications");

            migrationBuilder.DropTable(
                name: "Obligations");

            migrationBuilder.DropTable(
                name: "TaxPayers");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
