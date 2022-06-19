using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStoreFinalProject.Migrations
{
    public partial class modelToComputerModelColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "ComputerModel",
                table: "Computers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 1,
                column: "ComputerModel",
                value: "notebook 360");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 2,
                column: "ComputerModel",
                value: "Latitude 7420");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 3,
                column: "ComputerModel",
                value: "MacBook Pro");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 4,
                column: "ComputerModel",
                value: "Zenbook Duo");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 5,
                column: "ComputerModel",
                value: "VivoBook Flip");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 6,
                column: "ComputerModel",
                value: "Vostro 3510");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 7,
                column: "ComputerModel",
                value: "Omen");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 8,
                column: "ComputerModel",
                value: "MacBook Air");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerModel",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Model",
                value: "notebook 360");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 2,
                column: "Model",
                value: "Latitude 7420");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 3,
                column: "Model",
                value: "MacBook Pro");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 4,
                column: "Model",
                value: "Zenbook Duo");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 5,
                column: "Model",
                value: "VivoBook Flip");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 6,
                column: "Model",
                value: "Vostro 3510");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 7,
                column: "Model",
                value: "Omen");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 8,
                column: "Model",
                value: "MacBook Air");
        }
    }
}
