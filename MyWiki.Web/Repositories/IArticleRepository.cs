using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> GetAsync(Guid id);
        Task<Article> GetAsync(string Title);
        Task<Article> CreateAsync(Article article);
        Task<Article> UpdateAsync(Article article);
        Task<bool> DeleteAsync(Guid id);

    }
}
