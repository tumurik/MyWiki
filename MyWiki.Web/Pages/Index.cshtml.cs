using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;
using System.Text.RegularExpressions;

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
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string filterDate { get; set; }

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
            // 
            // If filter for date is not empty and date in MM/DD/YYYY format entered
            // Display articles matching this filter
            /*
            Regex regex = new Regex(@"0[1-9]|1[0-2]/(0|1)[0-9]|2[0-9]|3[0-1]/(19|20)\d\d$");

            if (
                filterDate != null && regex.IsMatch(filterDate.Trim())
                )
            {
                articles = (await articleRepository.GetAllDateFilterAsync(filterDate)).ToList();
                issueTypes = (await issueTypeRepository.GetAllAsync()).ToList();
                return Page();
            }
            else
             */
            if ( searchString != null && searchString.Any() )
            {
                articles = (await articleRepository.GetAllSearchAsync(searchString)).DistinctBy(x => x.Id).ToList();
            }
            else
            { 
                articles = (await articleRepository.GetAllAsync()).ToList();
            }

            issueTypes = (await issueTypeRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}