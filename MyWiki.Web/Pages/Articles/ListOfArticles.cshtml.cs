using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace MyWiki.Web.Pages.Articles
{
    public class ListOfArticlesModel : PageModel
    {
        private readonly MyWikiDbContext myWikiDbContext;

        public List<Article> Articles { get; set; }

        public ListOfArticlesModel(MyWikiDbContext myWikiDbContext)
        {
            this.myWikiDbContext = myWikiDbContext;
        }
        public async Task OnGet()
        {
            Articles = await myWikiDbContext.Articles.ToListAsync();
        }
    }
}



