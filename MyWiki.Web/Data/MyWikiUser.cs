using Microsoft.AspNetCore.Identity;

namespace MyWiki.Web.Data
{
    public class MyWikiUser: IdentityUser
    {
        public string Department { get; set; }
    }
}
