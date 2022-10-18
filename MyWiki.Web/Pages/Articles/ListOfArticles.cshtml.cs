using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Repositories;

namespace MyWiki.Web.Pages.Articles
{
    public class ListOfArticlesModel : PageModel
    {
        private readonly IArticleRepository articleRepository;

        public List<Article> articles { get; set; }

        public ListOfArticlesModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task OnGet()
        {
            articles = (await articleRepository.GetAllAsync())?.ToList();
        }
    }
}



