using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations.AuthDb
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "469680c0-fc6e-4099-b20e-04ad3dd67d11", "3de52b61-1c3c-43fe-8514-a6e9be46ed05" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7ec7f78-bcc9-40d5-a62e-df71d1695367", "3de52b61-1c3c-43fe-8514-a6e9be46ed05" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3de52b61-1c3c-43fe-8514-a6e9be46ed05");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5f7a2055-3dc9-435e-8b22-b5ad16f97815", 0, "371fe2d1-3dd0-48c0-933a-f94c456443cf", "Administration", "admin@mywiki.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEC9DNAsv0BSPi2D7KSDz2fSui5Y/xAphTZnTQs9ypN0g8epRKm5LWlYngLfZmSkL8w==", null, false, "2bb2d972-78a2-468f-a77e-aa33ebe725fa", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "469680c0-fc6e-4099-b20e-04ad3dd67d11", "5f7a2055-3dc9-435e-8b22-b5ad16f97815" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7ec7f78-bcc9-40d5-a62e-df71d1695367", "5f7a2055-3dc9-435e-8b22-b5ad16f97815" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "469680c0-fc6e-4099-b20e-04ad3dd67d11", "5f7a2055-3dc9-435e-8b22-b5ad16f97815" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7ec7f78-bcc9-40d5-a62e-df71d1695367", "5f7a2055-3dc9-435e-8b22-b5ad16f97815" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f7a2055-3dc9-435e-8b22-b5ad16f97815");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3de52b61-1c3c-43fe-8514-a6e9be46ed05", 0, "1d381d71-8e7d-44bc-b6c1-dc02a83bb0b1", "Administration", "admin@mywiki.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPTJayhS8B5GU8SYMVwuEzlbrB5w+WAqL57JTd5CmWS6KG7RFJnK45H0ZRMeJ/Z5HQ==", null, false, "0974b07e-9510-4af1-ad74-e33243162686", false, "admin@mywiki.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "469680c0-fc6e-4099-b20e-04ad3dd67d11", "3de52b61-1c3c-43fe-8514-a6e9be46ed05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7ec7f78-bcc9-40d5-a62e-df71d1695367", "3de52b61-1c3c-43fe-8514-a6e9be46ed05" });
        }
    }
}
