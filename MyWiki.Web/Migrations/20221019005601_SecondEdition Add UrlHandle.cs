using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations
{
    public partial class SecondEditionAddUrlHandle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlHandle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlHandle",
                table: "Articles");
        }
    }
}
