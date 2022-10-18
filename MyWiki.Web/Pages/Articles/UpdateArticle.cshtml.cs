using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;

namespace MyWiki.Web.Pages.Articles
{
    public class UpdateArticleModel : PageModel
    {
        private readonly MyWikiDbContext myWikiDbContext;

        [BindProperty]
        public Article Article { get; set; }

        public UpdateArticleModel(MyWikiDbContext myWikiDbContext)
        {
            this.myWikiDbContext = myWikiDbContext;
        }
        public async Task OnGet(Guid id)
        {
            Article = await myWikiDbContext.Articles.FindAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate() 
        {
            var chosenArticle = await myWikiDbContext.Articles.FindAsync(Article.Id);

            if (chosenArticle != null) 
            {
                chosenArticle.Title = Article.Title;
                chosenArticle.FullDescription = Article.FullDescription;
                chosenArticle.PublishedDate = Article.PublishedDate;
                chosenArticle.Author = Article.Author;
                chosenArticle.Visible = Article.Visible;
            }

            await myWikiDbContext.SaveChangesAsync();
            return RedirectToPage("/Articles/ListOfArticles");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var chosenArticle = await myWikiDbContext.Articles.FindAsync(Article.Id);

            if (chosenArticle != null)
            {
                myWikiDbContext.Articles.Remove(chosenArticle);
                await myWikiDbContext.SaveChangesAsync();
                return RedirectToPage("/Articles/ListOfArticles");
            }
            return Page();
        }
    }
}
