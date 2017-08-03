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
using pktexiservice.HelperClasses;

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
        
        
        /// <summary>
        /// Here admin ca see all the drivers 
        /// </summary>
        /// <returns>list of drivers</returns>
        // GET: api/AddDriver
        public IHttpActionResult Get()
        {
              try
                {
                    var Drivers = Helper.GetUsersInRole("Driver");
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
       
        // GET: api/AddDriver/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// Admin can add existing user to driver by there email.
        /// It removes user from customer role.
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>message driver added with driver email</returns>
        // POST: api/AddDriver
        public IHttpActionResult Post(string email)
        {
            var UserManager =  new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.RemoveFromRole(User.Id, "Customer");
            UserManager.AddToRole(User.Id, "Driver");

            return Json(User.Email + " : Driver Added"); 
        }

      

         /// <summary>
         /// This removes driver and add to customer role
         /// </summary>
         /// <param name="email">email of registered driver</param>
         /// <returns>message driver removed with driver email</returns>
        // DELETE: api/AddDriver/5
        public IHttpActionResult Delete(string email)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.RemoveFromRole(User.Id, "Driver");
            UserManager.AddToRole(User.Id, "Customer");
            return Json(User.Email+" : Driver Removed");
        }

       
    }
}
