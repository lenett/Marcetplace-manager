using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.Migrations
{
    public partial class _22101903 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Companies");
        }
    }
}
