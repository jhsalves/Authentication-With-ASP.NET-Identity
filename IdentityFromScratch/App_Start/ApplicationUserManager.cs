using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch.App_Start
{
    public class ApplicationUserManager : UserManager<CustomUser>
    {
        public ApplicationUserManager(UserStore<CustomUser> userStore) :
            base(userStore)
        { }

        //Os paramentros provem da chamada em Startup.Configuration
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
        {
            var userStore = new UserStore<CustomUser>(context.Get<ApplicationDbContext>());

            return new ApplicationUserManager(userStore);
        }
    }
}