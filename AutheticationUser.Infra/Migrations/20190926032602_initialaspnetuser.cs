using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationUser.Infra.Migrations
{
    public partial class initialaspnetuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "93321fc5-a74a-4baf-a4bb-33b7e6b3a9e3", "3bdc8d01-d92f-4af9-a6dd-6f9d99b759eb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ba59758f-3066-4120-a3c8-e944d9cc86f6", "90f9b687-fe4b-45e7-88d8-a4ec14c317f2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41f37a46-dddd-42fe-8bcf-b39e1bb8c3f6", 0, "bc7bb97a-7bf3-4ab7-801c-82b9570cd96d", "admin@admin.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEOGoaQslQsijOfj7E2k54Z0fW9BTljVL4FFOIw7I29OkdVu9XNx97cKTfRSSVC0ZtQ==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d7e47671-db6c-409d-8012-dcc09ebfc9c0", 0, "2a770c56-1387-4714-a938-0fc980c58390", "user@user.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBTzSaY//fn/2et245GujQW1sJkrD+FyBw/weEssixaeoyGMwiNT2AGf1bNK0btC5Q==", null, false, null, false, "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "41f37a46-dddd-42fe-8bcf-b39e1bb8c3f6", "bc7bb97a-7bf3-4ab7-801c-82b9570cd96d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d7e47671-db6c-409d-8012-dcc09ebfc9c0", "2a770c56-1387-4714-a938-0fc980c58390" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba59758f-3066-4120-a3c8-e944d9cc86f6", 0, "90f9b687-fe4b-45e7-88d8-a4ec14c317f2", "admin@admin.com", true, false, null, null, null, "1234", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93321fc5-a74a-4baf-a4bb-33b7e6b3a9e3", 0, "3bdc8d01-d92f-4af9-a6dd-6f9d99b759eb", "user@user.com", true, false, null, null, null, "1234", null, false, null, false, "user" });
        }
    }
}
