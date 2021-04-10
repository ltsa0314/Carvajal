using Microsoft.EntityFrameworkCore.Migrations;

namespace Carvajal.Infraestructure.Data.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "Email", "Identification", "LastName", "Name", "Password", "TypeIdentificationId" },
                values: new object[] { 1, "ltsa0314@gmail.com", "1110544973", "Sanchez Arevalo", "Leidy Tatina", "Tatiana@2021", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
