using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.Model.Migrations
{
    public partial class update20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, 23, "emTom@gmail.com", "Tom", "123123", "Surname" },
                    { 2, 26, "emAlice@gmail.com", "Alice", "123123", "Surname" },
                    { 3, 28, "emSam@gmail.com", "Sam", "123123", "Surname" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Body", "Header", "UserId" },
                values: new object[,]
                {
                    { 1, "BodyNews1", "Header1", 1 },
                    { 2, "BodyNews2", "Header2", 2 },
                    { 3, "BodyNews3", "Header3", 2 }
                });
        }
    }
}
