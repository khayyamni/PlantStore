using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plant_StoreBack.Migrations
{
    public partial class UpdateInterestedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "interesteds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "interesteds");
        }
    }
}
