using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plant_StoreBack.Migrations
{
    public partial class UpdateHelpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc2",
                table: "Helps",
                newName: "Desc3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc3",
                table: "Helps",
                newName: "Desc2");
        }
    }
}
