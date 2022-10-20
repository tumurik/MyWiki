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
        private readonly IIssueTypeRepository issueTypeRepository;

        public List<Article> articles { get; set; }
        public string[] articleTypes { get; set; } = { "Support issue", "Technical issue", "Template" };
        public List<IssueType> issueTypes { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IArticleRepository articleRepository,
            IIssueTypeRepository issueTypeRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
            this.issueTypeRepository = issueTypeRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            articles = (await articleRepository.GetAllAsync()).ToList();
            issueTypes = (await issueTypeRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}