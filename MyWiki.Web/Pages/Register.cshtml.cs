using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWiki.Web.Models.ViewModels;

namespace MyWiki.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = RegisterViewModel.Username,
                    Email = RegisterViewModel.Email,
                    //Department = RegisterViewModel.Department
                };
                var identityResult = await userManager.CreateAsync(user, RegisterViewModel.Password);
            }
            catch (Exception e)
            {
                ViewData["Error"] = e;
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
