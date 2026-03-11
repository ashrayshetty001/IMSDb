using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSDb.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_accounts",
                columns: new[] { "id", "Password", "Role", "UserName" },
                values: new object[] { 1, "admin", "Administrator", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_accounts",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
