using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleRepository articleRepository;
        public List<Article> articles { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IArticleRepository articleRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            articles = (await articleRepository.GetAllAsync()).ToList();

            return Page();
        }
    }
}