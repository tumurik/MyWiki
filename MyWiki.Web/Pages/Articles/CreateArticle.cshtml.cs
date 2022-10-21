using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Models.ViewModels;
using MyWiki.Web.Repositories;
using System;

namespace MyWiki.Web.Pages.Articles
{
    public class CreateArticleModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

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
