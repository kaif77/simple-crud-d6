using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_crud.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammeCoordinator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programmes");
        }
    }
}
