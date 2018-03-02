using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace WebApplication1_identity.Pages
{
    public class IndexModel : PageModel
    {
        public IIdentity Identity1 { get; set; }
        public void OnGet()
        {
            string myname=User.Identity.Name;
            Identity1 = User.Identity;

        }
    }
}
