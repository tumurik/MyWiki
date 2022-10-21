using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<IEnumerable<Article>> GetAllAsync(string type);
        Task<IEnumerable<Article>> GetAllByCategorySearchAsync(string type, string searchString);
        Task<IEnumerable<Article>> GetAllSearchAsync(string searchString);
        Task<IEnumerable<Article>> GetAllDateFilterAsync(string filterDate);
        Task<Article> GetAsync(Guid id);
        Task<Article> GetAsync(string Title);
        Task<Article> CreateAsync(Article article);
        Task<Article> UpdateAsync(Article article);
        Task<bool> DeleteAsync(Guid id);

    }
}
