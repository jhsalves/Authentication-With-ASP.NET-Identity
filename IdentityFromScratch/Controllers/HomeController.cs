using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var context = new ApplicationDbContext();
            var store = new UserStore<CustomUser>(context);
            var manager = new UserManager<CustomUser>(store);

            //SignIn
            var signInManager = new SignInManager<CustomUser, string>(manager,
                HttpContext.GetOwinContext().Authentication);


            var email = "foobar.com";
            var user = await manager.FindByEmailAsync(email);
            var password = "Passw0rd";

            if(user == null)
            {
                user = new CustomUser
                {
                    UserName = email,
                    Email = email,
                    Firstname = "Super",
                    Lastname = "Admin"
                };

                await manager.CreateAsync(user, password);
            }
            else
            {
                //user.Firstname = "Super";
                //user.Lastname = "Admin";
                //await manager.UpdateAsync(user);
                var passwordHasher = new PasswordHasher();

                var result = await signInManager.PasswordSignInAsync(user.UserName, password, true, false);


                if (result == SignInStatus.Success)
                {
                    return Content($"Hello {user.Firstname} {user.Lastname}");
                }
            }

            return Content("Hello Identity");
        }
    }
}