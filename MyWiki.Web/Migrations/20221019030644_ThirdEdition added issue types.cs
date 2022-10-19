using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWiki.Web.Migrations
{
    public partial class ThirdEditionaddedissuetypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes",
                column: "ArticleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueTypes_Articles_ArticleId",
                table: "IssueTypes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueTypes_Articles_ArticleId",
                table: "IssueTypes");

            migrationBuilder.DropIndex(
                name: "IX_IssueTypes_ArticleId",
                table: "IssueTypes");
        }
    }
}
