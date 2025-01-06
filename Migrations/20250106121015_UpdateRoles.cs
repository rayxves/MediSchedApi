using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediSchedApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a74691c5-cbdb-4f1e-8e22-be1a7e4091c7");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d6ba2c3e-1f0a-432f-914e-89cdbe415d82");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ff6d98e7-eab4-481b-98e1-b5d79451731c");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a74691c5-cbdb-4f1e-8e22-be1a7e4091c7", null, "Paciente", "PACIENTE" },
                    { "d6ba2c3e-1f0a-432f-914e-89cdbe415d82", null, "Médico", "MEDICO" },
                    { "ff6d98e7-eab4-481b-98e1-b5d79451731c", null, "Adm", "ADM" }
                });
        }
    }
}
