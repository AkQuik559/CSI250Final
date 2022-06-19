using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStoreFinalProject.Migrations
{
    public partial class seedComputerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "ID", "CompanyName", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 1, "Hp", "notebook 360", 899.99m, 2019 },
                    { 2, "Dell", "Latitude 7420", 2029.00m, 2022 },
                    { 3, "Apple", "MacBook Pro", 3499.00m, 2021 },
                    { 4, "Asus", "Zenbook Duo", 2299.00m, 2022 },
                    { 5, " Asus", "VivoBook Flip", 269.00m, 2022 },
                    { 6, "Dell", "Vostro 3510", 629.00m, 2022 },
                    { 7, "Hp", "Omen", 2349.99m, 2021 },
                    { 8, "Apple", "MacBook Air", 1199.00m, 2022 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}
