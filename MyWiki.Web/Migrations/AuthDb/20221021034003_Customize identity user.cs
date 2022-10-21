using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations.AuthDb
{
    public partial class Customizeidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3de52b61-1c3c-43fe-8514-a6e9be46ed05",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d381d71-8e7d-44bc-b6c1-dc02a83bb0b1", "AQAAAAEAACcQAAAAEPTJayhS8B5GU8SYMVwuEzlbrB5w+WAqL57JTd5CmWS6KG7RFJnK45H0ZRMeJ/Z5HQ==", "0974b07e-9510-4af1-ad74-e33243162686" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3de52b61-1c3c-43fe-8514-a6e9be46ed05",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11c3bf95-9b84-4515-914c-0d814a53026f", "AQAAAAEAACcQAAAAEMWn5NQPgxkPPwBr9CTb4vVg9x1nhH5GBkKBrumaeMVUWH5Vog5JLnfj+Qwn/bTN9Q==", "dfe6553b-121a-4c7f-bca9-c0f5a7acb8a4" });
        }
    }
}
