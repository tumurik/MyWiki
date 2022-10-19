using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations
{
    public partial class addnavigationpropertyissuetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes",
                column: "ArticleId",
                unique: true);
        }
    }
}
