using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationUser.Infra.Migrations
{
    public partial class initialaspnetusermanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "41f37a46-dddd-42fe-8bcf-b39e1bb8c3f6", "bc7bb97a-7bf3-4ab7-801c-82b9570cd96d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d7e47671-db6c-409d-8012-dcc09ebfc9c0", "2a770c56-1387-4714-a938-0fc980c58390" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41f37a46-dddd-42fe-8bcf-b39e1bb8c3f6", 0, "bc7bb97a-7bf3-4ab7-801c-82b9570cd96d", "admin@admin.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEOGoaQslQsijOfj7E2k54Z0fW9BTljVL4FFOIw7I29OkdVu9XNx97cKTfRSSVC0ZtQ==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d7e47671-db6c-409d-8012-dcc09ebfc9c0", 0, "2a770c56-1387-4714-a938-0fc980c58390", "user@user.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBTzSaY//fn/2et245GujQW1sJkrD+FyBw/weEssixaeoyGMwiNT2AGf1bNK0btC5Q==", null, false, null, false, "user" });
        }
    }
}
