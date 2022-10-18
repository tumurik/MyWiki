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

        public async Task<IActionResult> OnPost()
        {
            var Article = new Article()
            {
                Title = CreateArticleRequest.Title,
                FullDescription = CreateArticleRequest.FullDescription,
                PublishedDate = CreateArticleRequest.PublishedDate,
                Author = "Default",
                Visible = true
            };
            /*
             * change issue type model
             * 
            var IssueType = new IssueType()
            {
                Type =  CreateIssueTypeRequest.ArticleType
            };

            myWikiDbContext.IssueTypes.Add(IssueType);  
            */
            await myWikiDbContext.Articles.AddAsync(Article);
            await myWikiDbContext.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
