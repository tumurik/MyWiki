using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.Articles
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        public Article article { get; set; }

        public ArticleDetailsModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            article = await articleRepository.GetAsync(urlHandle);
            return Page();
        }
    }
}
