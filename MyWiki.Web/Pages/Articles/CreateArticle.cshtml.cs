using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Models.ViewModels;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.Articles
{
    public class CreateArticleModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        [BindProperty]
        public CreateArticle CreateArticleRequest { get; set; }

        public CreateArticleModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var article = new Article()
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
                await articleRepository.CreateAsync(article);
            }
            catch (Exception e)
            {
                ViewData["Error"] = e;
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
