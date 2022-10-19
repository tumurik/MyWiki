using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Repositories
{
    public interface IIssueTypeRepository
    {
        Task<IEnumerable<IssueType>> GetAllAsync();
    }
}
