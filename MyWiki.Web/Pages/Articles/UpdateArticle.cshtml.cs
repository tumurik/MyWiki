using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.Articles
{
    [Authorize]
    public class UpdateArticleModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        [BindProperty]
        public Article article { get; set; }
        [BindProperty]
        public string articleType { get; set; }
        //[BindProperty]
        public List<SelectListItem> articleTypeDropdownList { get; set; }

        public UpdateArticleModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task OnGet(Guid id)
        {
            article = await articleRepository.GetAsync(id);

            // join(',',...) instead concat when a few categories apply
            articleType = string.Concat(article.IssueTypes.Select(x => x.Type));

            // Generating select dropdown for article types
            // with current article type selected
            articleTypeDropdownList = new List<SelectListItem>();
            bool isSelected = false;
            List<string> articleTypes = new List<string> { "Support issue", "Technical issue", "Template" };

            if (articleTypes != null)
            {
                foreach (var type in articleTypes)
                {
                    isSelected = false;
                    if (type == articleType)
                    {
                        isSelected = true;
                    }
                    articleTypeDropdownList.Add(new SelectListItem
                    {
                        Text = type,
                        Value = type,
                        Selected = isSelected
                    });

                }
            }
        }

        public async Task<IActionResult> OnPostUpdate()
            {
                try
                {
                    article.IssueTypes = new List<IssueType> { new IssueType { Type = articleType } };

                    await articleRepository.UpdateAsync(article);
                    return RedirectToPage("/Articles/ListOfArticles");
                }
                catch (Exception e)
                {
                    ViewData["Error"] = e;
                    return Page();
                }
                
            }

        public async Task<IActionResult> OnPostDelete()
            {
                if (await articleRepository.DeleteAsync(article.Id))
                {
                    return RedirectToPage("/Articles/ListOfArticles");
                }
                else
                {
                    return Page();
                }
            }

        }
}
