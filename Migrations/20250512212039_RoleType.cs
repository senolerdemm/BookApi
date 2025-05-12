using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RoleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0369d9d4-28de-46c6-9824-65ba6c65ae4e", null, "Admin", "ADMIN" },
                    { "56dbe90b-8748-4225-8b20-89fb152f2c3f", null, "Editor", "EDITOR" },
                    { "a7b3cc84-e642-457b-9586-76ed6958df94", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0369d9d4-28de-46c6-9824-65ba6c65ae4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56dbe90b-8748-4225-8b20-89fb152f2c3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b3cc84-e642-457b-9586-76ed6958df94");
        }
    }
}
