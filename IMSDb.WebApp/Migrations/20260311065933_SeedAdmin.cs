using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSDb.WebApp.Migrations
{
    
    public partial class SeedAdmin : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_accounts",
                columns: new[] { "id", "Password", "Role", "UserName" },
                values: new object[] { 1, "admin", "Administrator", "admin" });
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_accounts",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
