using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pktexiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.HelperClasses
{
    public static class Helper
    {
        public static List<ApplicationUser> GetUsersInRole(string roleName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var role = roleManager.FindByName(roleName).Users.First();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usersInRole = UserManager.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
                return usersInRole;
            }
            
        }
    }
}