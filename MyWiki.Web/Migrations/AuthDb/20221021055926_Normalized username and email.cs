using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations.AuthDb
{
    public partial class Normalizedusernameandemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f7a2055-3dc9-435e-8b22-b5ad16f97815",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d544360-9584-4e4a-a04c-c8db640bc7e3", "ADMIN@MYWIKI.COM", "ADMIN", "AQAAAAEAACcQAAAAECPJW+GXdjboD8Vs5NlXpAooOes6J0h2HGsRyxI6ylThXhou06OWjc4H8xpxmhdFSw==", "370eb7d1-304f-4a78-b78e-b0ef87ded501" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f7a2055-3dc9-435e-8b22-b5ad16f97815",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "371fe2d1-3dd0-48c0-933a-f94c456443cf", null, null, "AQAAAAEAACcQAAAAEC9DNAsv0BSPi2D7KSDz2fSui5Y/xAphTZnTQs9ypN0g8epRKm5LWlYngLfZmSkL8w==", "2bb2d972-78a2-468f-a77e-aa33ebe725fa" });
        }
    }
}
