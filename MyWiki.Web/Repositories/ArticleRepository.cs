using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyWikiDbContext myWikiDbContext;

        public ArticleRepository(MyWikiDbContext myWikiDbContext)
        {
            this.myWikiDbContext = myWikiDbContext;
        }
        public async Task<Article> CreateAsync(Article article)
        {
            await myWikiDbContext.Articles.AddAsync(article);
            await myWikiDbContext.SaveChangesAsync();

            return article;
        }      

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await myWikiDbContext.Articles.Include(nameof(Article.IssueTypes))
                        .ToListAsync();
        }

        public async Task<Article> GetAsync(string urlHandle)
        {
            return await myWikiDbContext.Articles.Include(nameof(Article.IssueTypes))
                        .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<Article> GetAsync(Guid id)
        {
            return await myWikiDbContext.Articles.Include(nameof(Article.IssueTypes))
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            var chosenArticle = await GetAsync(article.Id);

            if (chosenArticle != null)
            {
                chosenArticle.Title = article.Title;
                chosenArticle.UrlHandle = article.Title?.ToLower().Replace(" ", "-");
                chosenArticle.FullDescription = article.FullDescription;
                chosenArticle.PublishedDate = article.PublishedDate;
                chosenArticle.Author = article.Author;
                chosenArticle.Visible = article.Visible;

                if (article.IssueTypes != null && article.IssueTypes.Any()) 
                {
                    //Delete chosenArticle issue type
                    myWikiDbContext.IssueTypes.RemoveRange(chosenArticle.IssueTypes);
                    //Change chosenArticle issue type
                    article.IssueTypes.ToList().ForEach(x => x.ArticleId = chosenArticle.Id);
                    await myWikiDbContext.IssueTypes.AddRangeAsync(article.IssueTypes);
                }
            }

            await myWikiDbContext.SaveChangesAsync();
            return chosenArticle;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var chosenArticle = await GetAsync(id);

            if (chosenArticle != null)
            {
                myWikiDbContext.Articles.Remove(chosenArticle);
                await myWikiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
