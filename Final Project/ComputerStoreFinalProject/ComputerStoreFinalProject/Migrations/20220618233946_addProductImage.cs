using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStoreFinalProject.Migrations
{
    public partial class addProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Computers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Computers");
        }
    }
}
