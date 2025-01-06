using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class AddConsulationAndConsulationReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "45f47d42-68e0-4710-a311-289334ac8d77");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8655d349-f068-4c6a-9309-ee03979b1fb5");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "94a85b8b-27e1-4b66-a927-fb3fca47e148");

            migrationBuilder.CreateTable(
                name: "ConsulationReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicoId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ConsultationCount = table.Column<int>(type: "integer", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsulationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsulationReports_AspNetUsers_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<string>(type: "text", nullable: false),
                    MedicoId = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_AspNetUsers_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultations_AspNetUsers_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a6261b5-80b8-4041-995e-a4a69a8c8e35", null, "Médico", "MEDICO" },
                    { "4fb0bfe0-d227-44f3-a7fd-c3a2b6455fc2", null, "Adm", "ADM" },
                    { "6fef74b5-5060-4d88-bc41-52c757d70110", null, "Paciente", "PACIENTE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsulationReports_MedicoId",
                table: "ConsulationReports",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedicoId",
                table: "Consultations",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PacienteId",
                table: "Consultations",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsulationReports");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1a6261b5-80b8-4041-995e-a4a69a8c8e35");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4fb0bfe0-d227-44f3-a7fd-c3a2b6455fc2");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6fef74b5-5060-4d88-bc41-52c757d70110");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45f47d42-68e0-4710-a311-289334ac8d77", null, "Paciente", "PACIENTE" },
                    { "8655d349-f068-4c6a-9309-ee03979b1fb5", null, "Adm", "ADM" },
                    { "94a85b8b-27e1-4b66-a927-fb3fca47e148", null, "Médico", "MEDICO" }
                });
        }
    }
}
