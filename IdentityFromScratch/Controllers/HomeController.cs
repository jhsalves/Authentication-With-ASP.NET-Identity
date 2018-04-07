using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityFromScratch.App_Start;
using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var email = "foobar.com";
            var user = await UserManager.FindByEmailAsync(email);
            var password = "Passw0rd";
            var roles = ApplicationRoleManager.Create(HttpContext.GetOwinContext());

            if(!await roles.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Admin });
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.IT))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.IT });
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.Accounting))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Accounting });
            }

            if (user == null)
            {
                user = new CustomUser
                {
                    UserName = email,
                    Email = email,
                    Firstname = "Super",
                    Lastname = "Admin"
                };

                await UserManager.CreateAsync(user, password);
            }
            else
            {
                if(!await UserManager.IsInRoleAsync(user.Id, SecurityRoles.Admin)) {
                    await UserManager.AddToRoleAsync(user.Id, SecurityRoles.Admin);
                }
            }

            return Content("Hello Identity");
        }
    }
}