using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using MyWiki.Web.Data;
using MyWiki.Web.Models.ViewModels;

namespace MyWiki.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<MyWikiUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<MyWikiUser> userManager)
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
                var user = new MyWikiUser
                {
                    UserName = RegisterViewModel.Username,
                    Email = RegisterViewModel.Email,
                    Department = RegisterViewModel.Department
                };

                var identityResult = await userManager.CreateAsync(user, RegisterViewModel.Password);
                if (!identityResult.Succeeded) 
                {
                    ViewData["Error"] = new Exception("Something went wrong!");
                    return Page();
                }

                var addRoleResult = await userManager.AddToRoleAsync(user, "User");
                if (!addRoleResult.Succeeded)
                {
                    ViewData["Error"] = new Exception("Something went wrong!");
                    return Page();
                }

                return RedirectToPage("/Index");
            }
            catch (Exception e)
            {
                ViewData["Error"] = e;
                return Page();
            }
        }
    }
}
