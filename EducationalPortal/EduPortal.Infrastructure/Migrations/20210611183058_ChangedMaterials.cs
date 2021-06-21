using Microsoft.EntityFrameworkCore.Migrations;

namespace EduPortal.Infrastructure.Migrations
{
    public partial class ChangedMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Materials");
        }
    }
}
