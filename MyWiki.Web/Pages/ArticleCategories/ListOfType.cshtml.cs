using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.ArticleCategories
{
    public class ListOfTypeModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        public List<Article> articles { get; set; }

        public ListOfTypeModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<IActionResult> OnGet(string type)
        {
            articles = (await articleRepository.GetAllAsync(type)).ToList();
            return Page();
        }
    }
}
