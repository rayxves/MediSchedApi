using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndFixSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.AddColumn<List<string>>(
                name: "Keywords",
                table: "Specialties",
                type: "text[]",
                nullable: false);

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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7433da68-7212-4115-96b3-d6927c2a02a6", null, "Adm", "ADM" },
                    { "a9a8429a-2a6c-4aad-9027-8d9c9be30e33", null, "Paciente", "PACIENTE" },
                    { "b1b93a23-142f-458e-ad85-b6784851cba5", null, "Médico", "MEDICO" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Keywords", "Name" },
                values: new object[,]
                {
                    { 1, new List<string> { "pressão alta", "dor no peito", "coração", "infarto", "cardíaco" }, "Cardiologia" },
                    { 2, new List<string> { "criança", "vacinas", "crescimento", "doenças infantis", "pediátrico" }, "Pediatria" },
                    { 3, new List<string> { "pele", "acne", "erupções cutâneas", "cabelos", "unhas" }, "Dermatologia" },
                    { 4, new List<string> { "dor de cabeça", "nervos", "convulsão", "neurológico", "esclerose múltipla" }, "Neurologia" },
                    { 5, new List<string> { "saúde da mulher", "gestação", "ciclo menstrual", "anticoncepcional", "exames ginecológicos" }, "Ginecologia" },
                    { 6, new List<string> { "olhos", "vista", "lentes", "miopia", "astigmatismo", "cirurgia ocular" }, "Oftalmologia" },
                    { 7, new List<string> { "ossos", "fraturas", "coluna", "artrose", "músculos", "cirurgia ortopédica" }, "Ortopedia" },
                    { 8, new List<string> { "saúde mental", "depressão", "ansiedade", "transtornos mentais", "psicoterapia" }, "Psiquiatria" },
                    { 9, new List<string> { "idoso", "envelhecimento", "demência", "Alzheimer", "saúde do idoso" }, "Geriatria" },
                    { 10, new List<string> { "ouvido", "nariz", "garganta", "sinusite", "amigdalite", "cirurgia otorrinolaringológica" }, "Otolaringologia" }
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7433da68-7212-4115-96b3-d6927c2a02a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9a8429a-2a6c-4aad-9027-8d9c9be30e33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1b93a23-142f-458e-ad85-b6784851cba5");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Specialties");

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

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
