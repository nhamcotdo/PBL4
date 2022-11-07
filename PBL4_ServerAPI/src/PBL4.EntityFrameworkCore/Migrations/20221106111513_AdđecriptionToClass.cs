using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL4.Migrations
{
    public partial class AdđecriptionToClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "classes",
                table: "PBL4Classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "classes",
                table: "PBL4Classes");
        }
    }
}
