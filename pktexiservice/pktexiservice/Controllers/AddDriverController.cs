using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pktexiservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace pktexiservice.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddDriverController : ApiController
    {
        /// <summary>
        /// Here admin can 
        /// -get all drivers
        /// -add drivers
        /// -remove drivers
        /// *request must have .....?email=driver@company.com
        /// *admin can auth using access_token
        /// </summary>
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/AddDriver
        public IHttpActionResult Get()
        {
              try
                {
                    var Drivers = GetUsersInRole("Driver");
                    List<string> driverNames = new List<string>();
                    foreach (var item in Drivers)
                    {
                        driverNames.Add(item.Email);
                    }
                    return Json(driverNames);
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }
           
        }
        public List<ApplicationUser> GetUsersInRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = roleManager.FindByName(roleName).Users.First();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usersInRole = UserManager.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
            return usersInRole;
        }
        // GET: api/AddDriver/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddDriver
        public  IHttpActionResult Post(string email)
        {
            var UserManager =  new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.AddToRole(User.Id, "Driver");

            return Json(User.Email + " Driver Added"); 
        }

        // PUT: api/AddDriver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddDriver/5
        public IHttpActionResult Delete(string email)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.RemoveFromRole(User.Id, "Driver");
            return Json(User.Email+" Driver Removed");
        }

       
    }
}
