using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Models.ViewModels;
using MyWiki.Web.Repositories;
using System;

namespace MyWiki.Web.Pages.Articles
{
    [Authorize]
    public class CreateArticleModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        //private readonly UserManager<MyWikiUser> userManager;

        [BindProperty]
        public CreateArticle CreateArticleRequest { get; set; }
        [BindProperty]
        public string articleType { get; set; }

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
                //var user = await userManager.FindByNameAsync("");
                var article = new Article()
                {
                    Title = CreateArticleRequest.Title,
                    UrlHandle = (CreateArticleRequest.Title?.ToLower().Replace(" ", "-")),
                    FullDescription = CreateArticleRequest.FullDescription,
                    PublishedDate = CreateArticleRequest.PublishedDate,
                    Author = "Default",
                    Visible = true,
                    IssueTypes = new List<IssueType> { new IssueType { Type = articleType } }                    
                };

                await articleRepository.CreateAsync(article);
                return RedirectToPage("/Index");
            }
            catch (Exception e)
            {
                ViewData["Error"] = e;
                return Page();
            }
            
        }
    }
}
