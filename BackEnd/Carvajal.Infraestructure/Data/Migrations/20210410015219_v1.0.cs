using Microsoft.EntityFrameworkCore.Migrations;

namespace Carvajal.Infraestructure.Data.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TypeIdentification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIdentification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    TypeIdentificationId = table.Column<int>(nullable: false),
                    Identification = table.Column<string>(maxLength: 21, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_TypeIdentification_TypeIdentificationId",
                        column: x => x.TypeIdentificationId,
                        principalSchema: "dbo",
                        principalTable: "TypeIdentification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TypeIdentification",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "CC - Cedula Ciudadania" },
                    { 2, "RC - Registro Civil" },
                    { 3, "TI - Tarjeta Identidad" },
                    { 4, "CE - Cedula Extrajera" },
                    { 5, "PA - Pasaporte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeIdentificationId",
                schema: "dbo",
                table: "User",
                column: "TypeIdentificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TypeIdentification",
                schema: "dbo");
        }
    }
}
