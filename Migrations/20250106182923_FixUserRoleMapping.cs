using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoleMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b82d889-0c6c-4d7e-875b-dd7db71f1a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50b2f2d3-bfeb-4789-84f9-c67d106291e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ebd04b-e26f-41b8-b1aa-f1dcc1bf4522");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1b82d889-0c6c-4d7e-875b-dd7db71f1a72", null, "Adm", "ADM" },
                    { "50b2f2d3-bfeb-4789-84f9-c67d106291e8", null, "Paciente", "PACIENTE" },
                    { "d5ebd04b-e26f-41b8-b1aa-f1dcc1bf4522", null, "Medico", "MEDICO" }
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
