using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStoreFinalProject.Migrations
{
    public partial class seedAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "City", "Country", "CustomerID", "StreetName", "StreetNumber", "Unit", "Zip" },
                values: new object[] { 1, "Kent", "USA", 1, "SE 209th St", "12025", "", "98031" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Addresses",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
