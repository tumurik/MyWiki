using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Data;
using MyWiki.Web.Models.ViewModels;


namespace MyWiki.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<MyWikiUser> signInManager;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public LoginModel(SignInManager<MyWikiUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var signInResult = await signInManager.PasswordSignInAsync(
                LoginViewModel.Username, LoginViewModel.Password, false, false);
            if (signInResult.Succeeded)
            {
                return RedirectToPage("Index");
            }
            else 
            {
                ViewData["Error"] = new Exception("Something went wrong!");
                return Page();
            }
        }
    }
}
