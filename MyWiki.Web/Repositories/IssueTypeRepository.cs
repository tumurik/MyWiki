using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Repositories
{
    public class IssueTypeRepository : IIssueTypeRepository
    {
        private readonly MyWikiDbContext myWikiDbContext;

        public IssueTypeRepository(MyWikiDbContext myWikiDbContext)
        {
            this.myWikiDbContext = myWikiDbContext;
        }
        public async Task<IEnumerable<IssueType>> GetAllAsync()
        {
            var issueTypes = await myWikiDbContext.IssueTypes.ToListAsync();

            return issueTypes.DistinctBy(x => x.Type);
        }
    }
}
