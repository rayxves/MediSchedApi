using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class FixUserErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78753008-a151-42c4-ab83-80c9a6a773b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f81cfdb-52aa-4c30-933b-be96d76000f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f48525a7-6487-4815-b0f2-65aef4ce9f0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "047a6f5c-5327-4618-a422-3ebd0a91bce9", null, "Paciente", "PACIENTE" },
                    { "3b4f3975-d8dd-4989-aa3e-3e5932cb773e", null, "Adm", "ADM" },
                    { "70c7abdf-02dc-4254-a9f7-dc05632d308e", null, "Medico", "MEDICO" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "047a6f5c-5327-4618-a422-3ebd0a91bce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4f3975-d8dd-4989-aa3e-3e5932cb773e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c7abdf-02dc-4254-a9f7-dc05632d308e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78753008-a151-42c4-ab83-80c9a6a773b0", null, "Medico", "MEDICO" },
                    { "7f81cfdb-52aa-4c30-933b-be96d76000f8", null, "Adm", "ADM" },
                    { "f48525a7-6487-4815-b0f2-65aef4ce9f0f", null, "Paciente", "PACIENTE" }
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
        }
    }
}
