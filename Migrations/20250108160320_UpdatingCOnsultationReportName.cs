using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCOnsultationReportName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsulationReports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13f25865-81c8-49ae-a233-e9688138f124");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4830d9b8-f34a-4d4b-a01e-6165eb597a91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a495a88e-41d5-42bf-b457-1a8c6006d4bd");

            migrationBuilder.CreateTable(
                name: "ConsultationReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicoId = table.Column<string>(type: "text", nullable: false),
                    DoctorSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationCount = table.Column<int>(type: "integer", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationReports_AspNetUsers_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationReports_DoctorSpecialties_DoctorSpecialtyId",
                        column: x => x.DoctorSpecialtyId,
                        principalTable: "DoctorSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e47ee85-e05b-4620-8fc2-9778f4225a28", null, "Adm", "ADM" },
                    { "e8d1b853-d5b5-45e7-a484-ddcb0e063ff5", null, "Paciente", "PACIENTE" },
                    { "f5cf898a-a5aa-4dd6-bc9c-72057738643f", null, "Medico", "MEDICO" }
                });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Keywords",
                value: new List<string> { "pressão alta", "dor no peito", "coração", "infarto", "cardíaco" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Keywords",
                value: new List<string> { "criança", "vacinas", "crescimento", "doenças infantis", "pediátrico" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Keywords",
                value: new List<string> { "pele", "acne", "erupções cutâneas", "cabelos", "unhas" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Keywords",
                value: new List<string> { "dor de cabeça", "nervos", "convulsão", "neurológico", "esclerose múltipla" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Keywords",
                value: new List<string> { "saúde da mulher", "gestação", "ciclo menstrual", "anticoncepcional", "exames ginecológicos" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Keywords",
                value: new List<string> { "olhos", "vista", "lentes", "miopia", "astigmatismo", "cirurgia ocular" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "Keywords",
                value: new List<string> { "ossos", "fraturas", "coluna", "artrose", "músculos", "cirurgia ortopédica" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "Keywords",
                value: new List<string> { "saúde mental", "depressão", "ansiedade", "transtornos mentais", "psicoterapia" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "Keywords",
                value: new List<string> { "idoso", "envelhecimento", "demência", "Alzheimer", "saúde do idoso" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "Keywords",
                value: new List<string> { "ouvido", "nariz", "garganta", "sinusite", "amigdalite", "cirurgia otorrinolaringológica" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "Keywords",
                value: new List<string>());

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationReports_DoctorSpecialtyId",
                table: "ConsultationReports",
                column: "DoctorSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationReports_MedicoId",
                table: "ConsultationReports",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultationReports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e47ee85-e05b-4620-8fc2-9778f4225a28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d1b853-d5b5-45e7-a484-ddcb0e063ff5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5cf898a-a5aa-4dd6-bc9c-72057738643f");

            migrationBuilder.CreateTable(
                name: "ConsulationReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    MedicoId = table.Column<string>(type: "text", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_ConsulationReports_DoctorSpecialties_DoctorSpecialtyId",
                        column: x => x.DoctorSpecialtyId,
                        principalTable: "DoctorSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13f25865-81c8-49ae-a233-e9688138f124", null, "Paciente", "PACIENTE" },
                    { "4830d9b8-f34a-4d4b-a01e-6165eb597a91", null, "Medico", "MEDICO" },
                    { "a495a88e-41d5-42bf-b457-1a8c6006d4bd", null, "Adm", "ADM" }
                });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Keywords",
                value: new List<string> { "pressão alta", "dor no peito", "coração", "infarto", "cardíaco" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Keywords",
                value: new List<string> { "criança", "vacinas", "crescimento", "doenças infantis", "pediátrico" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Keywords",
                value: new List<string> { "pele", "acne", "erupções cutâneas", "cabelos", "unhas" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Keywords",
                value: new List<string> { "dor de cabeça", "nervos", "convulsão", "neurológico", "esclerose múltipla" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Keywords",
                value: new List<string> { "saúde da mulher", "gestação", "ciclo menstrual", "anticoncepcional", "exames ginecológicos" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Keywords",
                value: new List<string> { "olhos", "vista", "lentes", "miopia", "astigmatismo", "cirurgia ocular" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "Keywords",
                value: new List<string> { "ossos", "fraturas", "coluna", "artrose", "músculos", "cirurgia ortopédica" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "Keywords",
                value: new List<string> { "saúde mental", "depressão", "ansiedade", "transtornos mentais", "psicoterapia" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "Keywords",
                value: new List<string> { "idoso", "envelhecimento", "demência", "Alzheimer", "saúde do idoso" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "Keywords",
                value: new List<string> { "ouvido", "nariz", "garganta", "sinusite", "amigdalite", "cirurgia otorrinolaringológica" });

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "Keywords",
                value: new List<string>());

            migrationBuilder.CreateIndex(
                name: "IX_ConsulationReports_DoctorSpecialtyId",
                table: "ConsulationReports",
                column: "DoctorSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsulationReports_MedicoId",
                table: "ConsulationReports",
                column: "MedicoId");
        }
    }
}
