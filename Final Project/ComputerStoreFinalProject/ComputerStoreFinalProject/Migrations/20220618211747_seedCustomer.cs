using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStoreFinalProject.Migrations
{
    public partial class seedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Mobile", "Phone" },
                values: new object[,]
                {
                    { 1, "bmayhou0@imageshack.us", "Brynne", "Mayhou", "758-562-6470", "966-926-0620" },
                    { 2, "mvela1@flickr.com", "Margaretha", "Vela", "684-651-3264", "217-861-7584" },
                    { 3, "amapother2@is.gd", "Amalia", "Mapother", "673-740-4441", "595-428-3323" },
                    { 4, "qpadden3@dedecms.com", "Padden", "Quill", "506-944-1295", "177-620-3793" },
                    { 5, "btesh4@nymag.com", "Basilius", "Tesh", "500-717-3485", "941-489-2754" },
                    { 6, "TJ@gmail.com", "Tommy", "Jones", "559-469-3485", "559-469-2354" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
