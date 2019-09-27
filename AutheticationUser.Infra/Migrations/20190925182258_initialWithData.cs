using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationUser.Infra.Migrations
{
    public partial class initialWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ba59758f-3066-4120-a3c8-e944d9cc86f6", 0, "90f9b687-fe4b-45e7-88d8-a4ec14c317f2", "admin@admin.com", true, false, null, null, null, "1234", null, false, null, false, "Admin" },
                    { "93321fc5-a74a-4baf-a4bb-33b7e6b3a9e3", 0, "3bdc8d01-d92f-4af9-a6dd-6f9d99b759eb", "user@user.com", true, false, null, null, null, "1234", null, false, null, false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Porções" },
                    { 2, "Pizzas" },
                    { 3, "Hamburguers" },
                    { 4, "Bebidas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "93321fc5-a74a-4baf-a4bb-33b7e6b3a9e3", "3bdc8d01-d92f-4af9-a6dd-6f9d99b759eb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ba59758f-3066-4120-a3c8-e944d9cc86f6", "90f9b687-fe4b-45e7-88d8-a4ec14c317f2" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
