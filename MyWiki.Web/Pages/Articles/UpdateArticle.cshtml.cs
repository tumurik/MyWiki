using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.Articles
{
    public class UpdateArticleModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        [BindProperty]
        public Article article { get; set; }

        public UpdateArticleModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task OnGet(Guid id)
        {
            article = await articleRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate() 
        {
            try
            {
                await articleRepository.UpdateAsync(article);
            }
            catch (Exception e)
            {
                ViewData["Error"] = e;
                return Page();
            }
            return RedirectToPage("/Articles/ListOfArticles");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if(await articleRepository.DeleteAsync(article.Id))
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
