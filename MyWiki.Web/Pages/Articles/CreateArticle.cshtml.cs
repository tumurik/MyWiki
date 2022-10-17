using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Models.ViewModels;

namespace MyWiki.Web.Pages.Articles
{
    public class CreateArticleModel : PageModel
    {
        private readonly MyWikiDbContext myWikiDbContext;

        [BindProperty]
        public CreateArticle CreateArticleRequest { get; set; }

        public CreateArticleModel(MyWikiDbContext myWikiDbContext)
        {
            this.myWikiDbContext = myWikiDbContext;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var Article = new Article()
            {
                Title = CreateArticleRequest.Title,
                FullDescription = CreateArticleRequest.FullDescription,
                PublishedDate = CreateArticleRequest.PublishedDate,
                Author = "Default",
                Visible = true
            };

            myWikiDbContext.Articles.Add(Article);
            myWikiDbContext.SaveChanges();
        }
    }
}
