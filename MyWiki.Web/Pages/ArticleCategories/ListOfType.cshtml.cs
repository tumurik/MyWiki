using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.ArticleCategories
{
    [Authorize]
    public class ListOfTypeModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        public List<Article> articles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }

        public ListOfTypeModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<IActionResult> OnGet(string type)
        {
            // To fix - sometimes show wrong category article(only support issue)
            // In database everything ok, so problem in code
            string articlesType = type;

            if (searchString != null && searchString.Any())
            {
                articles = (await articleRepository.GetAllByCategorySearchAsync(articlesType, searchString)).ToList();
            }
            else
            {
                articles = (await articleRepository.GetAllAsync(articlesType)).ToList();
            }

            return Page();
        }
    }
}
