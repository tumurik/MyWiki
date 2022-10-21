using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;

namespace MyWiki.Web.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<MyWikiUser> signInManager;

        public LogoutModel(SignInManager<MyWikiUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
