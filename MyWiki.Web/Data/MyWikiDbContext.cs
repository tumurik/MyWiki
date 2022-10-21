using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Data
{
    public class MyWikiDbContext : DbContext
    {
        public MyWikiDbContext(DbContextOptions<MyWikiDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
    }
}
