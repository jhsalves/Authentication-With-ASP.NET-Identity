using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    [Authorize(Roles ="accounting,admin")]
    public class AccountingController : BaseController
    {
        // GET: Accounting
        public ActionResult Index()
        {
            //roles do usuario atual:
            //var roles = UserManager.GetRolesAsync(User.Identity.GetUserId());


            if (User.IsInRole(SecurityRoles.Admin))
            {
                return Content("Wellcome to accounting");
            }
            else
            {
                return Content("You aren't an admin user");
            }
            
        }
    }
}