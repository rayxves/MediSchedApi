using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class FixSintax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                table: "DoctorSpecialties");

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

            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "DoctorSpecialties",
                newName: "SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpecialties_SpecialtyId",
                table: "DoctorSpecialties",
                newName: "IX_DoctorSpecialties_SpecialityId");

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "4d456802-edab-4a3b-8b26-c4e6a4f78cee", null, "Medico", "MEDICO" },
            //         { "c840853c-c690-4488-9b8a-9c46c29ad71e", null, "Paciente", "PACIENTE" },
            //         { "e9465ae7-3750-4d2b-a860-33a889c7640c", null, "Adm", "ADM" }
            //     });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialityId",
                table: "DoctorSpecialties",
                column: "SpecialityId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialityId",
                table: "DoctorSpecialties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d456802-edab-4a3b-8b26-c4e6a4f78cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c840853c-c690-4488-9b8a-9c46c29ad71e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9465ae7-3750-4d2b-a860-33a889c7640c");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "DoctorSpecialties",
                newName: "SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpecialties_SpecialityId",
                table: "DoctorSpecialties",
                newName: "IX_DoctorSpecialties_SpecialtyId");

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "1e47ee85-e05b-4620-8fc2-9778f4225a28", null, "Adm", "ADM" },
            //         { "e8d1b853-d5b5-45e7-a484-ddcb0e063ff5", null, "Paciente", "PACIENTE" },
            //         { "f5cf898a-a5aa-4dd6-bc9c-72057738643f", null, "Medico", "MEDICO" }
            //     });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
